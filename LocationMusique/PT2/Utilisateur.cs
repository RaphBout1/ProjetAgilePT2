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
        #region listView Emprunt
        List<EMPRUNTER> EnsembleEmpruntPouvantEtreAfficher = new List<EMPRUNTER>();
        int page;
        #endregion
        Connexion fenetrePrecedente;

        public Utilisateur(ABONNÉS uti, Connexion fenetrePrecedente)
        {
            InitializeComponent();
            InitialiserListView();
            utilisateur = uti;
            nom.Text = uti.NOM_ABONNÉ;
            prenom.Text = uti.PRÉNOM_ABONNÉ;
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            rendreButton.Visible = false;
            this.fenetrePrecedente = fenetrePrecedente;
        }

        public Utilisateur(ABONNÉS uti)
        {
            InitializeComponent();
            InitialiserListView();
            utilisateur = uti;
            nom.Text = uti.NOM_ABONNÉ;
            prenom.Text = uti.PRÉNOM_ABONNÉ;
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            rendreButton.Visible = false;
            
        }
   
        /// <summary>
        /// Actualise l'affichage des emprunts
        /// </summary>        
        public void ActualiseListeEmprunté()
        {

            List<EMPRUNTER> listeFinale = new List<EMPRUNTER>();
            foreach (EMPRUNTER e in MesEmprunts())
            {
                listeFinale.Add(e);
            }
            enregistrerDansListe(listeFinale);
            Refresh();
        }

        /// <summary>
        /// Retourne la liste des emprunts de l'utilisateur
        /// </summary>
        /// <returns>La liste des emprunts de l'utilisateur</returns>
        public List<EMPRUNTER> MesEmprunts()
        {
            return (from em in musiqueSQL.EMPRUNTER
                    where em.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ
                    select em).ToList();
        }
    
        /// <summary>
        /// Tente de prolonger l'emprunt passé en paramètre
        /// </summary>
        /// <param name="emprunt">L'emprunt concerné</param>        
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
                    throw new ProlongementEmpruntException("L'album : " + emDb.ALBUMS.TITRE_ALBUM + "\n" +
                        "Emprunt déjà prolongé!");
                }
            }
            else
            {
                throw new ProlongementEmpruntException("Emprunt introuvable ou déjà rendu.");
            }
        }

        /// <summary>
        /// Renvoie true si l'emprunt de l'album sélectionné n'a jamais été prolongé.
        /// </summary>
        /// <param name="em">L'emprunt concerné</param>
        /// <returns>si l'emprunt est prolongeable ou non</returns>
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
                List<ALBUMS> listeRecommandation = new List<ALBUMS>();
                foreach (ALBUMS a in albums)
                {
                    listeRecommandation.Add(a);
                }
                UtilisateurUSEmprunt recommandationEmpruntable = new UtilisateurUSEmprunt(utilisateur, listeRecommandation, this);
                listViewConsultation.Items.Clear();
                this.Visible = false;
                recommandationEmpruntable.ShowDialog();
                Refresh();
            }
        }
        #endregion

        #endregion

        #region prolonger clic
         
        /// <summary>
        /// Appelle les fonctions nécessaires au prolongement de tous les emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolongerTousButton_Click(object sender, EventArgs e)
        {
            var mesEmprunts = (from em in musiqueSQL.EMPRUNTER where (em.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ) select em).ToList();
            int nbProlonges = 0;
            foreach (EMPRUNTER em in mesEmprunts)
            {
                if (empruntProlongeable(em))
                {
                    ProlongerEmprunt(em);
                    nbProlonges++;
                }
            }
            if (nbProlonges > 0)
            {
                ActualiseListeEmprunté();
            }
            MessageBox.Show(nbProlonges + " emprunts ont été prolongés.");
        }

        /// <summary>
        /// Appelle les fonctions nécessaires au prolongement d'un certain emprunt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prolonger1Button_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem i in listViewConsultation.SelectedItems)
                {
                    EMPRUNTER empruntCourant = retrouveEmprunter_ListViewItem(i);
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

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            listViewConsultation.Items.Clear();
            this.Visible = false;
            new UtilisateurUSEmprunt(utilisateur,this).ShowDialog();
            enCours.Visible = false;
            retard.Visible = false;
            rendreButton.Visible = false;
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
            rendreButton.Visible = false;
            enCours.Visible = true;
            retard.Visible = true;
            ActualiseListeEmprunté();
        }

        private void afficherRecommandations_Click(object sender, EventArgs e)
        {
            prolonger1Button.Visible = false;
            prolongerTousButton.Visible = false;
            rendreButton.Visible = false;
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
            enregistrerDansListe(empruntEnRetard());
            Refresh();
        }

        ///<summary>
        ///On actualise la liste qui est en train de fonctionner afin d'actualiser les informations
        ///</summary>
        private void actualiserListeEnCours()
        {
            enregistrerDansListe(empruntEnCours());
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
            List<EMPRUNTER> listefinale = new List<EMPRUNTER>();
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
            rendreButton.Visible = true;
            actualiserListeEnCours();
        }

        private void retard_Click(object sender, EventArgs e)
        {
            prolonger1Button.Visible = true;
            prolongerTousButton.Visible = true;
            rendreButton.Visible = true;
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
            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(70, 70);
            int compteurEmpruntTemp = 0;
            foreach (EMPRUNTER e in le)
            {
                #region rajout d'une ligne
                //création de l'item et mise en place titre
                ListViewItem item = new ListViewItem(e.ALBUMS.TITRE_ALBUM, compteurEmpruntTemp);
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
            #endregion
        }
        #endregion

        #region pagination
        /// <summary>
        /// Affiche la première page d'une liste et ses éléments, ainsi que les flèches pour changer de page.
        /// </summary>
        /// <param name="le">La liste d'emprunts</param>
        private void enregistrerDansListe(List<EMPRUNTER> le)
        {
            if (le.Count == 0) { MessageBox.Show("Il n'y a aucun album dans cette catégorie !"); }
            else
            {
                EnsembleEmpruntPouvantEtreAfficher = le;
                page = 0;
                boutonPageSuivant.Visible = true;
                boutonPageRetour.Visible = true;
                changerPage();
            }

        }

        /// <summary>
        /// En fonction de l'entier page, affiche la page actuelle et affiche 7 éléments par pages
        /// </summary>
        private void changerPage()
        {
            labelPage.Text = "Page : "+(page+1).ToString();
            int nmbEmpruntParPage =7;
            List<EMPRUNTER> listAAfficher = new List<EMPRUNTER>();
            for (int i = page * nmbEmpruntParPage; i < page * nmbEmpruntParPage + nmbEmpruntParPage; i++)
            {
                if (EnsembleEmpruntPouvantEtreAfficher.Count > i)
                {
                    listAAfficher.Add(EnsembleEmpruntPouvantEtreAfficher[i]);
                }
            }
            if (page == 0) { boutonPageRetour.Visible = false; }
            if (listAAfficher.Count< nmbEmpruntParPage)
            {
                boutonPageSuivant.Visible = false;
            }
            PlacerNouvelleInfo(listAAfficher);
        }

        #region bouton
        private void boutonPageSuivant_Click(object sender, EventArgs e)
        {
            page++;
            changerPage();
            boutonPageRetour.Visible = true;
        }

        private void boutonPageRetour_Click(object sender, EventArgs e)
        {
            page--;
            changerPage();
            boutonPageSuivant.Visible = true;
        }
        #endregion
        #endregion
        #endregion

        #region retrouve Element

        private EMPRUNTER retrouveEmprunter_ListViewItem(ListViewItem lvi)
        {
            return (from a in musiqueSQL.ALBUMS
                    join e in musiqueSQL.EMPRUNTER on a.CODE_ALBUM equals e.CODE_ALBUM
                    where a.TITRE_ALBUM == lvi.Text && e.DATE_RETOUR == null
                    select e).FirstOrDefault();
        }
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
        #endregion
        

        #region Importer Image
        public Image ConstructionImageDepuisByte(byte[] tabByte)
        {
            MemoryStream ms = new MemoryStream(tabByte);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion

        ///<summary>
        ///On change le mot de passe et ensuite on enregistre le nouveau mot de passe dans la base de données 
        ///</summary>
        public void changerMdp()
        {
            ChangerMdp changementMdp = new ChangerMdp(utilisateur);
            if (changementMdp.ShowDialog() == DialogResult.OK)
            {
                ABONNÉS aboAModif = (from ab in musiqueSQL.ABONNÉS where ab.CODE_ABONNÉ == utilisateur.CODE_ABONNÉ select ab).First();
                aboAModif.PASSWORD_ABONNÉ = changementMdp.nouveauMdp;
                musiqueSQL.SaveChanges();
            }
        }

        private void utilisateurChangerMdp_Click(object sender, EventArgs e)
        {
            changerMdp();
        }

        #region rendre Emprunt
        private void rendreButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listViewConsultation.SelectedItems)
            {
                EMPRUNTER empruntCourant = retrouveEmprunter_ListViewItem(i);
                rendreEmprunt(empruntCourant);
            }
            actualiserListeEnCours();
        }

        /// <summary>
        /// Méthode qui rend un emprunt
        /// </summary>
        /// <param name="m">L'emprunt en question</param>
        public void rendreEmprunt(EMPRUNTER m)
        {
            var bonEmprunt = from l in musiqueSQL.EMPRUNTER where l.CODE_ABONNÉ == m.CODE_ABONNÉ && l.CODE_ALBUM == m.CODE_ALBUM select l;
            bonEmprunt.First().DATE_RETOUR = DateTime.UtcNow;
            musiqueSQL.SaveChanges();
        }
        #endregion

        private void quitter_Click(object sender, EventArgs e)
        {
            fenetrePrecedente.Visible = true;
        }
    }
}
