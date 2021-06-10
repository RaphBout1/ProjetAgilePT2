using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT2
{
    public partial class Utilisateur : Form
    {

        private ABONNÉS utilisateur;
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Dictionary<GENRES, int> listeGenreEmprunte = new Dictionary<GENRES, int>();

        public Utilisateur(ABONNÉS uti)
        {
            InitializeComponent();
            utilisateur = uti;
            nom.Text = uti.NOM_ABONNÉ;
            prenom.Text = uti.PRÉNOM_ABONNÉ;
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            
        }

        /**
         * Actualise l'affichage des emprunts
         */
        public void ActualiseListeEmprunté()
        {
            listBoxConsultEmprunt.Items.Clear();
            foreach (EMPRUNTER e in NouveauxEmprunts())
            {
                listBoxConsultEmprunt.Items.Add(e);
            }
            Refresh();
        }

        public List<EMPRUNTER> NouveauxEmprunts()
        {
            return (from em in musiqueSQL.EMPRUNTER
                    where em.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                    select em).ToList();
        }

        /**
         * Tente de prolonger l'emprunt passé en paramètre
         */
        public void ProlongerEmprunt(EMPRUNTER em)
        {
            EMPRUNTER emDb = (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == em.CODE_ABONNÉ && e.CODE_ALBUM == em.CODE_ALBUM select e).FirstOrDefault();
            if (emDb != null && emDb.DATE_RETOUR == null)
            {
                if (empruntProlongeable(emDb, emDb.ALBUMS))
                {
                    musiqueSQL.EMPRUNTER.Remove(emDb);
                    musiqueSQL.SaveChanges();
                    emDb.DATE_RETOUR_ATTENDUE = emDb.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    musiqueSQL.EMPRUNTER.Add(emDb);
                    musiqueSQL.SaveChanges();
                }
                else
                {
                    throw new ProlongementEmpruntException("Emprunt déjà prolongé!");
                }
            }
            else
            {
                throw new ProlongementEmpruntException("Emprunt introuvable ou déjà rendu.");
            }
        }

        /*
         * Renvoie true si l'emprunt de l'album sélectionné n'a jamais été prolongé.
         */
        public bool empruntProlongeable(EMPRUNTER em, ALBUMS al)
        {
            if (em.DATE_EMPRUNT.AddDays(al.GENRES.DÉLAI).CompareTo(em.DATE_RETOUR_ATTENDUE) == 0 && em.DATE_RETOUR == null)
            {
                return true;
            }
            return false;
        }

        #region Recommandation
        /// <summary>
        /// Initialise le listage des recommandations
        /// </summary>
        private void Recommandation()
        {
            listeGenreEmprunte.Clear();
            ListerGenreEmprunte();
            ListageRecommandeAlbum();
        }

        #region Calcule Recommandation
        /// <summary>
        /// Etabli un ordre de grandeur par genre de musique consulté
        /// </summary>
        private void ListerGenreEmprunte()
        {
            foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
            {
                if (listeGenreEmprunte.ContainsKey(e.ALBUMS.GENRES))
                {
                    listeGenreEmprunte[e.ALBUMS.GENRES] += 1;
                }
                else
                {
                    listeGenreEmprunte.Add(e.ALBUMS.GENRES, 1);
                }
            }

        }
        /// <summary>
        /// Obtient la liste des albums recommandé, classé par ordre de priorité
        /// </summary>
        private void ListageRecommandeAlbum()
        {
            if (listeGenreEmprunte.Count() > 0)
            {
                int genre = listeGenreEmprunte.Aggregate((l, r) => l.Value > r.Value ? l : r).Key.CODE_GENRE;
                var albumsDuGenreDisponibles = (from alb in musiqueSQL.ALBUMS where alb.CODE_GENRE == genre select alb).ToList().Except(from e in musiqueSQL.EMPRUNTER where (e.ALBUMS.CODE_GENRE == genre && e.DATE_RETOUR == null) select e.ALBUMS).ToList();
                int maxAffichage = albumsDuGenreDisponibles.Count();
                int nombreAlbumsAAfficher = Math.Min(10, maxAffichage);
                var albums = (from a in albumsDuGenreDisponibles where a.CODE_GENRE == genre orderby a.EMPRUNTER.Count() select a).Take(nombreAlbumsAAfficher);
                foreach (ALBUMS a in albums)
                {
                    listBoxConsultEmprunt.Items.Add(a.TITRE_ALBUM);
                }
                Refresh();
            }
        }
        #endregion

        #endregion

        /**
         * Gère l'activation du bouton pour prolonger un emprunt (après sélection d'un item dans la listbox)
         */
        private void listBoxConsultEmprunt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxConsultEmprunt.SelectedItem != null)
            {
                prolonger1Button.Enabled = true;
            }
            else
            {
                prolonger1Button.Enabled = false;
            }
        }

        /**
         * Appelle les fonctions nécessaires au prolongement de tous les emprunts
         */
        private void prolongerTousButton_Click(object sender, EventArgs e)
        {
            foreach (EMPRUNTER em in utilisateur.EMPRUNTER)
            {
                try
                {
                    ProlongerEmprunt(em);
                }
                catch (Exception)
                {

                }
            }
            ActualiseListeEmprunté();
            MessageBox.Show("Tous vos emprunts prolongeables ont été prolongés d'un mois.");
        }

        /**
         * Appelle les fonctions nécessaires au prolongement d'un certain emprunt
         */
        private void prolonger1Button_Click(object sender, EventArgs e)
        {
            try
            {
                EMPRUNTER emprunt = (EMPRUNTER)listBoxConsultEmprunt.SelectedItem;
                ProlongerEmprunt(emprunt);
                ActualiseListeEmprunté();
                prolonger1Button.Visible = false;
                prolongerTousButton.Visible = false;
                MessageBox.Show("L'emprunt de l'album " + emprunt.ALBUMS.TITRE_ALBUM + " a bien été prolongé.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new UtilisateurUSEmprunt(utilisateur).ShowDialog();
            enCours.Visible = false;
            retard.Visible = false;
        }

        private void rendreButton_Click(object sender, EventArgs e)
        {
            new US14Rendre(utilisateur).ShowDialog();
            enCours.Visible = false;
            retard.Visible = false;
        }

        private void MAJButton_Click(object sender, EventArgs e)
        {
            ActualiseListeEmprunté();
            enCours.Visible = true;
            retard.Visible = true;
        }

        private void afficherEmprunts_Click(object sender, EventArgs e)
        {
            listBoxConsultEmprunt.Items.Clear();
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            enCours.Visible = true;
            retard.Visible = true;
            ActualiseListeEmprunté();
        }

        private void afficherRecommandations_Click(object sender, EventArgs e)
        {
            listBoxConsultEmprunt.Items.Clear();
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            enCours.Visible = false;
            retard.Visible = false;
            Recommandation();
        }
        /// <summary>
        /// Fourni une liste des emprunts de l'utilisateurs qui sont en retards
        /// </summary>
        /// <returns>La liste</returns>
        private List<EMPRUNTER> empruntEnRetard()
        {
            List<EMPRUNTER> listefinale = new List<EMPRUNTER>();
            foreach (EMPRUNTER i in utilisateur.EMPRUNTER)
            {
                if (i.enRetard())
                {
                    listefinale.Add(i);
                }
            }
            return listefinale;
        }
        /// <summary>
        /// Rempli la listebox avec tous les emprunts de l'utilisateur qui sont en retards.
        /// </summary>
        private void actualiserListeEnRetard()
        {
            listBoxConsultEmprunt.Items.Clear();
            foreach(EMPRUNTER i in empruntEnRetard())
            {
                listBoxConsultEmprunt.Items.Add(i);
            }
            Refresh();
        }

        private void actualiserListeEnCours()
        {
            listBoxConsultEmprunt.Items.Clear();
            foreach (EMPRUNTER i in empruntEnCours())
            {
                listBoxConsultEmprunt.Items.Add(i);
            }
            Refresh();
        }
        /// <summary>
        /// Fourni une liste des emprunts de l'utilisateurs qui sont en cours
        /// </summary>
        /// <returns>La liste</returns>
        private List<EMPRUNTER> empruntEnCours()
        {
            List<EMPRUNTER> listefinale = new List<EMPRUNTER>();
            foreach(EMPRUNTER i in utilisateur.EMPRUNTER){
                if(i.DATE_RETOUR == null)
                {
                    listefinale.Add(i);
                }

            }
            return listefinale;
        }

        private void enCours_Click(object sender, EventArgs e)
        {
            prolonger1Button.Visible = true;
            prolongerTousButton.Visible = true;
            actualiserListeEnCours();
        }

        private void retard_Click(object sender, EventArgs e)
        {
            prolonger1Button.Visible = true;
            prolongerTousButton.Visible = true;
            actualiserListeEnRetard();
        }
    }
}
