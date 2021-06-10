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
    public partial class UtilisateurUSEmprunt : Form
    {
        #region attribut
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Dictionary<int, ALBUMS> listeAlbumsEmpruntable = new Dictionary<int, ALBUMS>();
        Dictionary<int, int> caseY = new Dictionary<int, int>();
        List<ALBUMS> listeAlbumsVisualiser = new List<ALBUMS>();
        int compteurAlbum;
        int page;
        int nmbAlbum;
        ALBUMS albumAEmprunter;
        ABONNÉS utilisateur;
        #endregion

        #region Constructeur
        /// <summary>
        /// Unique constructeur de la classe,
        /// cette méthode initialise les 5 premiers albums empruntable et affiché
        /// </summary>
        /// <param name="utilisateur"> l'abonnée voulant emprunter un album </param>
        public UtilisateurUSEmprunt(ABONNÉS utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            InitialisationGlobaleDeVariable();
            ImplementeAlbumsEmpruntable(5);
        }

        /// <summary>
        /// Initialise des attribut de la page :
        ///     -Les compteur (page, nombre d'album visité dans la page)
        ///     -Les positions Y des zones de sélection des 5 albums dans l'affichage
        ///     -le nombre d'album globale de la base de donnée
        /// </summary>
        public void InitialisationGlobaleDeVariable()
        {
            monthCalendarClassique.Visible = false;// a enlever pour test
            compteurAlbum = 0;
            page = 0;
            labelPage.Text = "Page : " + page.ToString();
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
                                AfficheAlbumActuelle();
                            }
                            
                        }
                        compteurCase++;
                    }
                }
            }
        }
        #region affichage Selectionné
        private void AfficheAlbumActuelle()
        {
            boutonEmprunterAlbumPrecis.Visible = true;
            InfoNumero.Text = "N° : " + albumAEmprunter.CODE_ALBUM.ToString();
            InfoTitre.Text = albumAEmprunter.TITRE_ALBUM;
            InfoAnnee.Text = "Année : " + albumAEmprunter.ANNÉE_ALBUM.ToString();
            InfoEditeur.Text = "Editeur : " + albumAEmprunter.EDITEURS.NOM_EDITEUR;
            InfoGenre.Text = "Genre : " + albumAEmprunter.GENRES.LIBELLÉ_GENRE;
            InfoPrix.Text = "Prix : " + albumAEmprunter.PRIX_ALBUM.ToString() + " €";

        }
        #endregion
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
            AffectationCinqAlbum(5);
            AfficheAlbum();
            boutonRetour.Visible = true;
        }
        /// <summary>
        /// Méthode permettant d'aller à la page retour
        /// lors du clique sur le bouton précédant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonRetour_Click(object sender, EventArgs e)
        {
            page--;
            AffectationCinqAlbum(5);
            AfficheAlbum();
            boutonSuivant.Visible = true;
        }
        #endregion

        #region recherche des albums à afficher
        /// <summary>
        /// Implémente jusqu'à 5 album dans la liste des albums pouvant être emprunté
        /// ces derniers sont indexé par ordre croisant de leur CODE_ALBUM
        /// </summary>
        /// <param name="ensemble"> la position correspondant à l'ensemble d'album devant être recherché (par intervalle de 5)</param>
        public void ImplementeAlbumsEmpruntable(int ensemble)
        {

            var album = from a in musiqueSQL.ALBUMS
                        where a.CODE_ALBUM < (page * 5) + ensemble && a.CODE_ALBUM >= (page * 5) + ensemble - 6
                        select a;
            Console.WriteLine("Nouvel liste : ");
            foreach (ALBUMS a in album)
            {
                bool enEmprunt = false;
                foreach (EMPRUNTER e in a.EMPRUNTER)
                {
                    if (e.DATE_RETOUR == null) { enEmprunt = true; }
                }
                if (!enEmprunt)
                {
                    bool dejaContenu = false;
                    int compteurInverse = compteurAlbum;
                    Console.WriteLine(" A examiner : " + a.CODE_ALBUM);
                    while (!dejaContenu && compteurInverse > compteurAlbum - 5 && compteurInverse > 0)
                    {
                        if (listeAlbumsEmpruntable.ContainsKey(compteurInverse))
                        {
                            Console.WriteLine("     Originale : " + listeAlbumsEmpruntable[compteurInverse].CODE_ALBUM);
                            if (listeAlbumsEmpruntable[compteurInverse].Equals(a)) { dejaContenu = true; }
                        }
                        compteurInverse--;
                    }
                    if (!dejaContenu)
                    {
                        listeAlbumsEmpruntable.Add(compteurAlbum, a);
                        compteurAlbum++;
                    }

                }
            }
            AffectationCinqAlbum(ensemble);
            AfficheAlbum();
        }
        /// <summary>
        /// Permet de selectionné les 5 albums à affiché
        /// </summary>
        /// <param name="ensemble"> la position correspondant à l'ensemble d'album devant être recherché (par intervalle de 5)</param>
        private void AffectationCinqAlbum(int ensemble)
        {
            listeAlbumsVisualiser.Clear();
            for (int index = 0; index < 5; index++)
            {
                if (listeAlbumsVisualiser.Count < 5)
                {
                    if (listeAlbumsEmpruntable.ContainsKey(index + (5 * page)))
                    {
                        listeAlbumsVisualiser.Add(listeAlbumsEmpruntable[index + (5 * page)]);
                    }
                    else
                    {
                        if ((page*5) + ensemble <= nmbAlbum - 5)
                        {
                            ensemble += 5;
                            ImplementeAlbumsEmpruntable(ensemble);
                        }
                        
                    }
                }
            }
        }
        #endregion

        #region affichage
        /// <summary>
        /// Permet d'afficher les 5 albums correspondant à la page actuelle.
        /// Active ou désactive les boutons de changement de page
        /// </summary>
        private void AfficheAlbum()
        {
            labelPage.Text = "Page : " + page.ToString();
            for (int index = 0; index < 5; index++)
            {
                switch (index)
                {
                    case 0:
                        if (listeAlbumsVisualiser.Count() >= 1)
                        {
                            Titre1.Text = listeAlbumsVisualiser[0].TITRE_ALBUM;
                            Genre1.Text = listeAlbumsVisualiser[0].GENRES.LIBELLÉ_GENRE;
                        }
                        else
                        {
                            Titre1.Text = "";
                            Genre1.Text = "";
                        }
                        break;
                    case 1:
                        if (listeAlbumsVisualiser.Count() >= 2)
                        {
                            Titre2.Text = listeAlbumsVisualiser[1].TITRE_ALBUM;
                            Genre2.Text = listeAlbumsVisualiser[1].GENRES.LIBELLÉ_GENRE;
                        }
                        else
                        {
                            Titre2.Text = "";
                            Genre2.Text = "";
                        }
                        break;
                    case 2:
                        if (listeAlbumsVisualiser.Count() >= 3)
                        {
                            Titre3.Text = listeAlbumsVisualiser[2].TITRE_ALBUM;
                            Genre3.Text = listeAlbumsVisualiser[2].GENRES.LIBELLÉ_GENRE;
                        }
                        else
                        {
                            Titre3.Text = "";
                            Genre3.Text = "";
                        }
                        break;
                    case 3:
                        if (listeAlbumsVisualiser.Count() >= 4)
                        {
                            Titre4.Text = listeAlbumsVisualiser[3].TITRE_ALBUM;
                            Genre4.Text = listeAlbumsVisualiser[3].GENRES.LIBELLÉ_GENRE;
                        }
                        else
                        {
                            Titre4.Text = "";
                            Genre4.Text = "";
                        }
                        break;
                    case 4:
                        if (listeAlbumsVisualiser.Count() >= 5)
                        {
                            Titre5.Text = listeAlbumsVisualiser[4].TITRE_ALBUM;
                            Genre5.Text = listeAlbumsVisualiser[4].GENRES.LIBELLÉ_GENRE;
                        }
                        else
                        {
                            Titre5.Text = "";
                            Genre5.Text = "";
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
                if (/*listeAlbumsVisualiser.Last().Equals(listeAlbumsEmpruntable.Last()) || */listeAlbumsVisualiser.Count() < 5)
                {
                    boutonSuivant.Visible = false;
                }
            }
        }
        #endregion
        #endregion


    }
}
