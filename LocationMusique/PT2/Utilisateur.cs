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
        List<ALBUMS> listeAlbumsRecommande = new List<ALBUMS>();

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
        private void ActualiseListeEmprunté()
        {
            if (utilisateur != null)
            {
                listBoxConsultEmprunt.Items.Clear();
                var emprunt = from ab in musiqueSQL.ABONNÉS
                              where ab.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                              join em in musiqueSQL.EMPRUNTER on ab.CODE_ABONNÉ equals em.CODE_ABONNÉ
                              select em;
                foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
                {
                    if (!utilisateur.EMPRUNTER.Contains(e))
                    {
                        utilisateur.EMPRUNTER.Add(e);
                    }
                    listBoxConsultEmprunt.Items.Add(e);
                }
            }
            Refresh();
        }

        /**
         * Tente de prolonger l'emprunt passé en paramètre
         */
        public void ProlongerEmprunt(EMPRUNTER em)
        {
            EMPRUNTER emDb = (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == em.CODE_ABONNÉ && e.CODE_ALBUM == em.CODE_ALBUM select e).FirstOrDefault();
            if (emDb != null && emDb.DATE_RETOUR == null)
            {
                if (emDb.DATE_EMPRUNT.AddDays(emDb.ALBUMS.GENRES.DÉLAI).CompareTo(emDb.DATE_RETOUR_ATTENDUE) == 0 && emDb.DATE_RETOUR == null)
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
            Dictionary<int, ALBUMS> listeAlbum = new Dictionary<int, ALBUMS>();
            foreach (KeyValuePair<GENRES, int> gi in listeGenreEmprunte)
            {
                foreach (ALBUMS a in gi.Key.ALBUMS)
                {
                    int cle = (100 * a.EMPRUNTER.Count) + (1000 * gi.Value);
                    while (listeAlbum.ContainsKey(cle)) { cle++; }
                    listeAlbum.Add(cle, a);
                }
            }
            foreach (KeyValuePair<int, ALBUMS> ia in listeAlbum.OrderBy(importance => importance.Key))
            {
                listeAlbumsRecommande.Add(ia.Value);
            }
            foreach (ALBUMS b in listeAlbumsRecommande)
            {
                recommandationsListBox.Items.Add(b.TITRE_ALBUM);
            }
            Refresh();
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
    }
}
