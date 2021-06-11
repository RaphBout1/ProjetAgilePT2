using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        EMPRUNTER empruntCourant = new EMPRUNTER();

        public Utilisateur(ABONNÉS uti)
        {
            InitializeComponent();
            InitialiserListView();
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

            List<EMPRUNTER> listeFinale = new List<EMPRUNTER>();
            foreach (EMPRUNTER e in NouveauxEmprunts())
            {
                listeFinale.Add(e);
            }
            PlacerNouvelleInfo(listeFinale);
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
        public void ProlongerEmprunt(EMPRUNTER emprunt)
        {
            EMPRUNTER emDb = (from em in musiqueSQL.EMPRUNTER where emprunt.CODE_ABONNÉ == em.CODE_ABONNÉ && emprunt.CODE_ALBUM == em.CODE_ALBUM select em).FirstOrDefault();
            if (emDb != null && emDb.DATE_RETOUR == null && emDb.ALBUMS != null)
            {
                if (empruntProlongeable(emDb))
                {
                    musiqueSQL.EMPRUNTER.Remove(emDb);
                    musiqueSQL.SaveChanges();
                    emDb.DATE_RETOUR_ATTENDUE = emDb.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    musiqueSQL.EMPRUNTER.Add(emDb);
                    musiqueSQL.SaveChanges();
                }
                else
                {
                    throw new ProlongementEmpruntException("L'album : "+emDb.ALBUMS.TITRE_ALBUM+"\n"+
                        "Emprunt déjà prolongé!");
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
        public bool empruntProlongeable(EMPRUNTER em)
        {
            if (em.DATE_EMPRUNT.AddDays(em.ALBUMS.GENRES.DÉLAI).CompareTo(em.DATE_RETOUR_ATTENDUE) == 0 && em.DATE_RETOUR == null)
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
                    //listBoxConsultEmprunt.Items.Add(a.TITRE_ALBUM);
                }
                Refresh();
            }
        }
        #endregion

        #endregion

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
                foreach(ListViewItem i in listViewConsultation.SelectedItems)
                {
                    Console.WriteLine(i.Text);
                    empruntCourant = retrouveEmprunter_ListViewItem(i);
                    ProlongerEmprunt(empruntCourant);
                    ActualiseListeEmprunté();
                    prolonger1Button.Visible = false;
                    prolongerTousButton.Visible = false;
                    MessageBox.Show("L'emprunt de l'album " + empruntCourant.ALBUMS.TITRE_ALBUM + " a bien été prolongé.");
                }
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
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            enCours.Visible = true;
            retard.Visible = true;
            ActualiseListeEmprunté();
        }

        private void afficherRecommandations_Click(object sender, EventArgs e)
        {
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
            var emprunt = from e in musiqueSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                          select e;
            List<EMPRUNTER> listefinale = new List<EMPRUNTER>();
            foreach (EMPRUNTER i in emprunt)
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
            PlacerNouvelleInfo(empruntEnRetard());
            Refresh();
        }

        private void actualiserListeEnCours()
        {
            PlacerNouvelleInfo(empruntEnCours());
            Refresh();
        }


        /// <summary>
        /// Fourni une liste des emprunts de l'utilisateurs qui sont en cours
        /// </summary>
        /// <returns>La liste</returns>
        private List<EMPRUNTER> empruntEnCours()
        {
            var emprunt = from e in musiqueSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                          select e;
            List < EMPRUNTER > listefinale = new List<EMPRUNTER>();
            foreach (EMPRUNTER i in emprunt)
            {
                if (i.DATE_RETOUR == null)
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


        #region ListView
        #region initialiser
        /// <summary>
        /// Initialise la listView
        /// </summary>
        private void InitialiserListView()
        {
            listViewConsultation.View = View.Details;
            listViewConsultation.GridLines = true;
            listViewConsultation.Columns.Add("Titre", -2, HorizontalAlignment.Left);
            listViewConsultation.Columns.Add("N°", -2, HorizontalAlignment.Left);
            listViewConsultation.Columns.Add("Date d'emprunt", -2, HorizontalAlignment.Center);
            listViewConsultation.Columns.Add("Date retour", -2, HorizontalAlignment.Center);
        }
        #endregion

        #region attibué info
        /// <summary>
        /// Permet de placer des emprunts dans la listView
        /// </summary>
        /// <param name="le">Une liste comportant les emprunts à afficher</param>
        private void PlacerNouvelleInfo(List<EMPRUNTER> le)
        {
            listViewConsultation.Items.Clear();
            if (le.Count == 0) { MessageBox.Show("Il n'y a aucun album dans cette catégorie !"); }
            ImageList imageListSmall = new ImageList();
            int compteurEmpruntTemp = 0;
            foreach (EMPRUNTER e in le)
            {
                #region rajout d'une ligne
                //création de l'item et mise en place titre
                ListViewItem item = new ListViewItem(e.ALBUMS.TITRE_ALBUM, compteurEmpruntTemp);
                item.SubItems.Add(e.CODE_ALBUM.ToString());
                //date emprunt
                item.SubItems.Add(e.DATE_EMPRUNT.ToString());
                //date de retour ou la date prévue
                if (e.DATE_RETOUR != null)
                {
                    item.SubItems.Add("Retourné le : " + e.DATE_RETOUR.ToString());
                }
                else
                {
                    //prolongé ou pas 
                    if (empruntProlongeable(e)) { item.SubItems.Add("A retourner pour le : " + e.DATE_RETOUR_ATTENDUE.ToString()); }
                    else { item.SubItems.Add("A retourner pour le : " + e.DATE_RETOUR_ATTENDUE.ToString() + " (Déjà prolongé)"); }
                }
                //image
                if (e.ALBUMS.POCHETTE != null)
                {
                    imageListSmall.Images.Add(ConstructionImageDepuisByte(e.ALBUMS.POCHETTE));
                }
                else
                {
                    imageListSmall.Images.Add(Image.FromFile(Path.GetFullPath("..\\..\\Image\\ParDéfaut")));
                }
                listViewConsultation.Items.Add(item);
                compteurEmpruntTemp++;
                #endregion
            }
            listViewConsultation.SmallImageList = imageListSmall;
            #region Taille
            //taille colonne
            listViewConsultation.AutoResizeColumn(0,
            ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewConsultation.AutoResizeColumn(1,
            ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewConsultation.AutoResizeColumn(2,
            ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewConsultation.AutoResizeColumn(3,
            ColumnHeaderAutoResizeStyle.ColumnContent);
            #endregion
        }
        #endregion
        #endregion

        #region Importer Image
        public Image ConstructionImageDepuisByte(byte[] tabByte)
        {
            MemoryStream ms = new MemoryStream(tabByte);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion

        /// <summary>
        /// Lors de la selection d'un élément, on définit un emprunt courant pour éxécuter des modifications futures
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewConsultation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewConsultation.SelectedItems != null) { prolonger1Button.Enabled = true; }
            else { prolonger1Button.Enabled = false; }
        }

        #region retrouve Element

        private EMPRUNTER retrouveEmprunter_ListViewItem(ListViewItem lvi)
        {
            return (from a in musiqueSQL.ALBUMS
                    join e in musiqueSQL.EMPRUNTER on a.CODE_ALBUM equals e.CODE_ALBUM
                    where a.TITRE_ALBUM == lvi.Text && e.DATE_RETOUR == null
                    select e).FirstOrDefault();
        }
        #endregion 
    }
}
