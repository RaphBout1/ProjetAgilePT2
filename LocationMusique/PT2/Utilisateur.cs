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
            Recommandation();
            ActualiseListeEmprunté();
        }

        /**
         * Actualise l'affichage des emprunts
         */
        public List<EMPRUNTER> ActualiseListeEmprunté()
        {
            List<EMPRUNTER> listePourTest = new List<EMPRUNTER>();
            if (utilisateur != null)
            {
                listBoxConsultEmprunt.Items.Clear();
                var emprunt = from em in musiqueSQL.EMPRUNTER
                              where em.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                              select em;
                foreach (EMPRUNTER e in emprunt)
                {
                    listePourTest.Add(e);
                    listBoxConsultEmprunt.Items.Add(e);
                }
            }

            Refresh();
            return listePourTest;
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
                var albumsDuGenre = listeGenreEmprunte.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                int nombreAlbumsAAfficher = Math.Min(10, albumsDuGenre.ALBUMS.Count());
                var albums = (from a in musiqueSQL.ALBUMS where a.CODE_GENRE == albumsDuGenre.CODE_GENRE orderby a.EMPRUNTER.Count() select a).Take(nombreAlbumsAAfficher);
                foreach (ALBUMS a in albums)
                {
                    recommandationsListBox.Items.Add(a.TITRE_ALBUM);
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
        }

        private void rendreButton_Click(object sender, EventArgs e)
        {
            new US14Rendre(utilisateur).ShowDialog();
        }

        private void MAJButton_Click(object sender, EventArgs e)
        {
            ActualiseListeEmprunté();
        }
    }
}
