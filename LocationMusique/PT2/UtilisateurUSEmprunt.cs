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
    public partial class UtilisateurUSEmprunt : Form
    {
        #region attribut
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Dictionary<int, ALBUMS> listeAlbumsEmpruntable = new Dictionary<int, ALBUMS>();
        Dictionary<int, int> caseY = new Dictionary<int, int>();
        List<ALBUMS> listeAlbumsVisualiser = new List<ALBUMS>();
        bool listePredefini;
        int compteurAlbum;
        int page;
        int nmbAlbum;
        ALBUMS albumAEmprunter;
        ABONNÉS utilisateur;
        Utilisateur fenetrePrecedente;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur par défaut de la classe,
        /// cette méthode initialise les 5 premiers albums empruntables et affichés
        /// </summary>
        /// <param name="utilisateur"> l'abonnée voulant emprunter un album </param>
        public UtilisateurUSEmprunt(ABONNÉS utilisateur, Utilisateur fenetrePrecedente)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            InitialisationGlobaleDeVariable();
            listePredefini = false;
            AffectationCinqAlbum(0);
            this.fenetrePrecedente = fenetrePrecedente;
        }

        public UtilisateurUSEmprunt(ABONNÉS utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            InitialisationGlobaleDeVariable();
            listePredefini = false;
            AffectationCinqAlbum(0);
        }

        /// <summary>
        /// Constructeur de la classe
        /// cette méthode initialise l'emprunt mais seulement
        /// parmis ceux d'une liste entrée en paramètre
        /// </summary>
        /// <param name="utilisateur">l'abonnée voulant emprunter</param>
        /// <param name="listeVoulu"> la liste d'album pouvant être consulté</param>
        public UtilisateurUSEmprunt(ABONNÉS utilisateur, List<ALBUMS> listeVoulu, Utilisateur fenetrePrecedente)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            InitialisationGlobaleDeVariable();
            InitialisationListeAlbumPredefini(listeVoulu);
            AffectationCinqAlbumPrédéfini(5);
            this.fenetrePrecedente = fenetrePrecedente;
        }

        /// <summary>
        /// Initialise la liste liste des albums empruntable
        /// avec la liste prédéfini
        /// </summary>
        /// <param name="listeVoulu"> liste prédéfini d'album, les seuls pouvant être affiché</param>
        public void InitialisationListeAlbumPredefini(List<ALBUMS> listeVoulu)
        {
            listePredefini = true;
            foreach (ALBUMS a in listeVoulu)
            {
                listeAlbumsEmpruntable.Add(compteurAlbum, a);
                compteurAlbum++;
            }
        }
        /// <summary>
        /// Initialise des attributs de la page :
        ///     -Les compteurs (page, nombre d'albums visités dans la page)
        ///     -Les positions Y des zones de sélection des 5 albums dans l'affichage
        ///     -le nombre d'albums global de la base de donnée
        /// </summary>
        public void InitialisationGlobaleDeVariable()
        {
            monthCalendarClassique.Visible = false;// a enlever pour test
            compteurAlbum = 0;
            page = 0;
            labelPage.Text = "Page : " + (page+1).ToString();
            caseY.Add(57, 212);
            caseY.Add(220, 375);
            caseY.Add(384, 539);
            caseY.Add(546, 701);
            caseY.Add(709, 864);
            nmbAlbum = (from a in musiqueSQL.ALBUMS
                        select a).Count();
        }
        #endregion

        #region interraction
        /// <summary>
        /// Permet d'envoyer une requête de création d'emprunt avec les éléments
        /// de l'album sélectionné sur la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonEmprunterAlbumPrecis_Click(object sender, EventArgs e)
        {
            creerEmprunt(utilisateur.CODE_ABONNÉ, albumAEmprunter.CODE_ALBUM, monthCalendarClassique.SelectionStart, monthCalendarClassique.SelectionStart.AddDays(albumAEmprunter.GENRES.DÉLAI));
        }

        /// <summary>
        /// Permet de calculer la position de la souris sur l'écran,
        /// De plus, elle permet de selectionner un emprunt précis sur la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> les paramètres et évenement de la souris</param>
        private void UtilisateurUSEmprunt_MouseDown(object sender, MouseEventArgs e)
        {
            Point souris = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
            if (souris.X >= 42 && souris.X <= 740)
            {
                int compteurCase = 0;
                bool trouveAlbum = false;
                foreach (KeyValuePair<int, int> ivv in caseY)
                {
                    if (listeAlbumsVisualiser.Count > compteurCase)
                    {
                        if (!trouveAlbum)
                        {
                            if (souris.Y >= ivv.Key && souris.Y <= ivv.Value)
                            {
                                albumAEmprunter = listeAlbumsVisualiser[compteurCase];
                                AfficheAlbumActuel();
                            }
                            
                        }
                        compteurCase++;
                    }
                }
            }
        }
        #region affichage Selectionné
        private void AfficheAlbumActuel()
        {
            boutonEmprunterAlbumPrecis.Visible = true;
            InfoNumero.Text = "N° : " + albumAEmprunter.CODE_ALBUM.ToString();
            InfoTitre.Text = albumAEmprunter.TITRE_ALBUM;
            InfoAnnee.Text = "Année : " + albumAEmprunter.ANNÉE_ALBUM.ToString();
            InfoEditeur.Text = "Editeur : " + albumAEmprunter.EDITEURS.NOM_EDITEUR;
            InfoGenre.Text = "Genre : " + albumAEmprunter.GENRES.LIBELLÉ_GENRE;
            InfoPrix.Text = "Prix : " + albumAEmprunter.PRIX_ALBUM.ToString() + " €";
            pictureBox1.Image = RefaireImage(byteArrayToImage(albumAEmprunter.POCHETTE), 266, 260);
        }
        #endregion
        #endregion

        #region Affichage des pochettes
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        } 

        private Image RefaireImage(Image im, int tailleX, int tailleY)
        {
            return (Image)(new Bitmap(im, new Size(tailleX, tailleY)));
        }



        #endregion

        #region Création de l'emprunt
        /// <summary>
        /// Permet de créer un emprunt dans la base de donnée
        /// </summary>
        /// <param name="CODEABO"> Le CODE_ABONNE de l'utilisateur empruntant l'album</param>
        /// <param name="CODEALB"> Le CODE_ALBUM de l'album emprunté</param>
        /// <param name="DATEMPR"> La date au moment de l'emprunt</param>
        /// <param name="DATERTR"> La date prévu pour le retour</param>
        public void creerEmprunt(int CODEABO, int CODEALB, DateTime DATEMPR, DateTime DATERTR)
        {
            var listempruntabo = from b in musiqueSQL.ABONNÉS where b.CODE_ABONNÉ == CODEABO select b.EMPRUNTER;
            foreach (EMPRUNTER e in listempruntabo.First())
            {
                if (e.CODE_ALBUM == CODEALB)
                {
                    musiqueSQL.EMPRUNTER.Remove(e);
                    musiqueSQL.SaveChanges();
                    break;
                }
            }
            EMPRUNTER nouvelEmprunt = new EMPRUNTER();
            nouvelEmprunt.CODE_ABONNÉ = CODEABO;
            nouvelEmprunt.CODE_ALBUM = CODEALB;
            nouvelEmprunt.DATE_EMPRUNT = DATEMPR;
            nouvelEmprunt.DATE_RETOUR_ATTENDUE = DATERTR;
            musiqueSQL.EMPRUNTER.Add(nouvelEmprunt);
            musiqueSQL.SaveChanges();
        }
        #endregion


        #region Changement de Page
        #region interaction bouton
        /// <summary>
        /// Méthode permettant d'aller à la page suivante 
        /// lors du clique sur le bouton correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonSuivant_Click(object sender, EventArgs e)
        {
            page++;
            changementDePage();
            boutonRetour.Visible = true;
        }
        /// <summary>
        /// Méthode permettant d'aller à la page retour
        /// lors du clique sur le bouton précédent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonRetour_Click(object sender, EventArgs e)
        {
            page--;
            changementDePage();
            boutonSuivant.Visible = true;
        }

        /// <summary>
        /// Effectue l'actualise des albums lors du changement de page
        /// </summary>
        private void changementDePage()
        {
            if (listePredefini)
            {
                listeAlbumsVisualiser.Clear();
                AffectationCinqAlbumPrédéfini(5);
                AfficheAlbum();
            }
            else
            {
                listeAlbumsVisualiser.Clear();
                AffectationCinqAlbum(5);
                AfficheAlbum();
            }
        }
        #endregion

        #region recherche des albums à afficher
        /// <summary>
        /// Implémente jusqu'à 5 albums dans la liste des albums empruntables
        /// ces derniers sont indexés par ordre croisant de leur CODE_ALBUM
        /// </summary>
        /// <param name="ensemble"> la position correspondant à l'ensemble d'album devant être recherché (par intervalle de 5)</param>
        public void ImplementeAlbumsEmpruntable(int ensemble)
        {
            string texte = rechercheBox.Text;
            var album = from a in musiqueSQL.ALBUMS
                        where a.CODE_ALBUM < (page * 5) + ensemble && a.CODE_ALBUM >= (page * 5) + ensemble - 5
                        select a;
            if (texte.Length > 0)
            {
                album = from a in musiqueSQL.ALBUMS
                            where a.CODE_ALBUM < (page * 5) + ensemble && a.CODE_ALBUM >= (page * 5) + ensemble - 5 && a.TITRE_ALBUM.Contains(texte)
                            select a;
            }
            Console.WriteLine("     Nouvel liste : ");
            foreach (ALBUMS a in album)
            {
                Console.WriteLine(" A examiner : " + a.CODE_ALBUM);
                bool enEmprunt = false;
                foreach (EMPRUNTER e in a.EMPRUNTER)
                {
                    if (e.DATE_RETOUR == null) { enEmprunt = true; }
                }
                if (!enEmprunt)
                {
                    Console.WriteLine("     A examiner : " + a.CODE_ALBUM);
                    if (compteurAlbum - 1 >= 0)
                    {
                        if(listeAlbumsEmpruntable[compteurAlbum-1].CODE_ALBUM < a.CODE_ALBUM)
                        {
                            listeAlbumsEmpruntable.Add(compteurAlbum, a);
                            compteurAlbum++;
                        }
                    }
                    else
                    {
                        listeAlbumsEmpruntable.Add(compteurAlbum, a);
                        compteurAlbum++;
                    }

                }
            }
        }
        /// <summary>
        /// Permet de selectionné les 5 albums à afficher
        /// </summary>
        /// <param name="ensemble"> la position correspondant à l'ensemble d'album devant être recherché (par intervalle de 5)</param>
        private void AffectationCinqAlbum(int ensemble)
        {
            int index = 0;
            while(listeAlbumsVisualiser.Count < 5 && ((page * 5) + ensemble) < (nmbAlbum - 5))
            {
                if (listeAlbumsEmpruntable.ContainsKey(index + (5 * page)))
                {
                    listeAlbumsVisualiser.Add(listeAlbumsEmpruntable[index + (5 * page)]);
                    index++;
                }
                else
                {
                    if ((page * 5) + ensemble <= nmbAlbum - 5)
                    {
                        ensemble += 5;
                        ImplementeAlbumsEmpruntable(ensemble);
                    }

                }
                
            }
            AfficheAlbum();
        }
        #endregion

        #region Selectionné dans liste prédéfini
        /// <summary>
        /// Permet de sélectionner 5 album par rapport à une liste prédéfini
        /// </summary>
        /// <param name="ensemble"></param>
        private void AffectationCinqAlbumPrédéfini(int ensemble)
        {
            int index = 0;
            bool fini=false;
            while (listeAlbumsVisualiser.Count < 5 && ((page * 5) + ensemble) < (nmbAlbum - 5) && !fini)
            {
                if (listeAlbumsEmpruntable.ContainsKey(index + (5 * page)))
                {
                    listeAlbumsVisualiser.Add(listeAlbumsEmpruntable[index + (5 * page)]);
                    index++;
                }
                else { fini = true; }
            }
            AfficheAlbum();
        }
        #endregion

        #region affichage
        /// <summary>
        /// Permet d'afficher les 5 albums correspondant à la page actuelle.
        /// Active ou désactive les boutons de changement de page
        /// </summary>
        private void AfficheAlbum()
        {
            labelPage.Text = "Page : " + (page+1).ToString();
            for (int index = 0; index < 5; index++)
            {
                switch (index)
                {
                    case 0:
                        if (listeAlbumsVisualiser.Count() >= 1)
                        {
                            Titre1.Text = listeAlbumsVisualiser[0].TITRE_ALBUM;
                            Genre1.Text = listeAlbumsVisualiser[0].GENRES.LIBELLÉ_GENRE;
                            if (listeAlbumsVisualiser[0].POCHETTE != null)
                            {
                                pochette1.Image = RefaireImage(byteArrayToImage(listeAlbumsVisualiser[0].POCHETTE), 161, 155);
                            }
                            else
                            {
                                pochette1.Image = null;
                            }
                        }
                        else
                        {
                            Titre1.Text = "";
                            Genre1.Text = "";
                            pochette1.Image = null;
                        }
                        break;
                    case 1:
                        if (listeAlbumsVisualiser.Count() >= 2)
                        {
                            Titre2.Text = listeAlbumsVisualiser[1].TITRE_ALBUM;
                            Genre2.Text = listeAlbumsVisualiser[1].GENRES.LIBELLÉ_GENRE;
                            if (listeAlbumsVisualiser[1].POCHETTE != null)
                            {
                                pochette2.Image = RefaireImage(byteArrayToImage(listeAlbumsVisualiser[1].POCHETTE), 161, 155);
                            }
                            else
                            {
                                pochette2.Image = null;
                            }
                        }
                        else
                        {
                            Titre2.Text = "";
                            Genre2.Text = "";
                            pochette2.Image = null;
                        }
                        break;
                    case 2:
                        if (listeAlbumsVisualiser.Count() >= 3)
                        {
                            Titre3.Text = listeAlbumsVisualiser[2].TITRE_ALBUM;
                            Genre3.Text = listeAlbumsVisualiser[2].GENRES.LIBELLÉ_GENRE;
                            if (listeAlbumsVisualiser[2].POCHETTE != null)
                            {
                                pochette3.Image = RefaireImage(byteArrayToImage(listeAlbumsVisualiser[2].POCHETTE), 161, 155);
                            }
                            else
                            {
                                pochette3.Image = null;
                            }
                        }
                        else
                        {
                            Titre3.Text = "";
                            Genre3.Text = "";
                            pochette3.Image = null;
                        }
                        break;
                    case 3:
                        if (listeAlbumsVisualiser.Count() >= 4)
                        {
                            Titre4.Text = listeAlbumsVisualiser[3].TITRE_ALBUM;
                            Genre4.Text = listeAlbumsVisualiser[3].GENRES.LIBELLÉ_GENRE;
                            if (listeAlbumsVisualiser[3].POCHETTE != null)
                            {
                                pochette4.Image = RefaireImage(byteArrayToImage(listeAlbumsVisualiser[3].POCHETTE), 161, 155);
                            }
                            else
                            {
                                pochette4.Image = null;
                            }
                        }
                        else
                        {
                            Titre4.Text = "";
                            Genre4.Text = "";
                            pochette4.Image = null;
                        }
                        break;
                    case 4:
                        if (listeAlbumsVisualiser.Count() >= 5)
                        {
                            Titre5.Text = listeAlbumsVisualiser[4].TITRE_ALBUM;
                            Genre5.Text = listeAlbumsVisualiser[4].GENRES.LIBELLÉ_GENRE;
                            if (listeAlbumsVisualiser[4].POCHETTE != null)
                            {
                                pochette5.Image = RefaireImage(byteArrayToImage(listeAlbumsVisualiser[4].POCHETTE), 161, 155);
                            }
                            else
                            {
                                pochette5.Image = null;
                            }
                        }
                        else
                        {
                            Titre5.Text = "";
                            Genre5.Text = "";
                            pochette5.Image = null;
                        }
                        break;
                }
            }
            if (listeAlbumsVisualiser.Count()>0)
            {
                if (listeAlbumsVisualiser[0].Equals(listeAlbumsEmpruntable[0]))
                {
                    boutonRetour.Visible = false;
                }
            }
            else 
            { 
                boutonSuivant.Visible = false;
            }
            if (listeAlbumsEmpruntable.ContainsKey(nmbAlbum))
            {
                if (listeAlbumsVisualiser.Count() < 5)
                {
                    boutonSuivant.Visible = false;
                }
            }
        }
        #endregion
        #endregion

        private void annuler_Click(object sender, EventArgs e)
        {
            fenetrePrecedente.Visible = true;
            this.Close();
        }

        private void rechercherButton_Click(object sender, EventArgs e)
        {
            compteurAlbum = 0;
            page = 0;
            listeAlbumsEmpruntable.Clear();
            listeAlbumsVisualiser.Clear();
            AffectationCinqAlbum(5);
            AfficheAlbum();
            boutonSuivant.Visible = true;
        }
    }
}
