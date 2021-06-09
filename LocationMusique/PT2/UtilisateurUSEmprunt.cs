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
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Dictionary<int, ALBUMS> listeAlbumsEmpruntable = new Dictionary<int, ALBUMS>();
        Dictionary<int, int> caseY = new Dictionary<int, int>();
        List<ALBUMS> listeAlbumsVisualiser = new List<ALBUMS>();
        int compteurAlbum;
        int page;
        int nmbAlbum;
        ALBUMS albumAEmprunter;
        ABONNÉS utilisateur;
        public UtilisateurUSEmprunt(ABONNÉS utilisateur)
        {
            InitializeComponent();
            compteurAlbum = 0;
            page = 0;
            InitialisationGlobaleDeVariable();
            ImplementeAlbumsEmpruntable(5);
            this.utilisateur = utilisateur;
        }
        #region initialisation de la page
        public void InitialisationGlobaleDeVariable()
        {
            caseY.Add(57, 212);
            caseY.Add(220, 375);
            caseY.Add(384, 539);
            caseY.Add(546, 701);
            caseY.Add(709, 864);
            nmbAlbum = (from a in musiqueSQL.ALBUMS
                        select a).Count();
        }
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
                            Console.WriteLine("     Originale : "+listeAlbumsEmpruntable[compteurInverse].CODE_ALBUM);
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
        #endregion

        #region interraction
        private void comboBoxTitreAlbumAEmprunter_SelectedIndexChanged(object sender, EventArgs e)
        {
            albumAEmprunter = (ALBUMS)comboBoxTitreAlbumAEmprunter.SelectedItem;

        }

        private void boutonEmprunterAlbumPrecis_Click(object sender, EventArgs e)
        {
            creerEmprunt(utilisateur.CODE_ABONNÉ, albumAEmprunter.CODE_ALBUM, monthCalendarClassique.SelectionStart, monthCalendarClassique.SelectionStart.AddDays(albumAEmprunter.GENRES.DÉLAI));


        }
        #endregion


        #region Création de l'emprunt
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
        private void boutonSuivant_Click(object sender, EventArgs e)
        {
            page++;
            AffectationCinqAlbum(5);
            AfficheAlbum();
        }
        private void boutonRetour_Click(object sender, EventArgs e)
        {
            page--;
            AffectationCinqAlbum(5);
            AfficheAlbum();
        }
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
                        ensemble += 5;
                        ImplementeAlbumsEmpruntable(ensemble);
                    }
                }
            }
        }
        private void AfficheAlbum()
        {
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
                        break;
                    case 1:
                        if (listeAlbumsVisualiser.Count() >= 2)
                        {
                            Titre2.Text = listeAlbumsVisualiser[1].TITRE_ALBUM;
                            Genre2.Text = listeAlbumsVisualiser[1].GENRES.LIBELLÉ_GENRE;
                        }
                        break;
                    case 2:
                        if (listeAlbumsVisualiser.Count() >= 3)
                        {
                            Titre3.Text = listeAlbumsVisualiser[2].TITRE_ALBUM;
                            Genre3.Text = listeAlbumsVisualiser[2].GENRES.LIBELLÉ_GENRE;
                        }
                        break;
                    case 3:
                        if (listeAlbumsVisualiser.Count() >= 4)
                        {
                            Titre4.Text = listeAlbumsVisualiser[3].TITRE_ALBUM;
                            Genre4.Text = listeAlbumsVisualiser[3].GENRES.LIBELLÉ_GENRE;
                        }
                        break;
                    case 4:
                        if (listeAlbumsVisualiser.Count() >= 5)
                        {
                            Titre5.Text = listeAlbumsVisualiser[4].TITRE_ALBUM;
                            Genre5.Text = listeAlbumsVisualiser[4].GENRES.LIBELLÉ_GENRE;
                        }
                        break;
                }
            }
            if (listeAlbumsVisualiser[0].Equals(listeAlbumsEmpruntable[0]))
            {
                boutonRetour.Visible = false;
                boutonSuivant.Visible = true;
            }
            else
            {
                boutonRetour.Visible = true;
            }
            if (listeAlbumsEmpruntable.ContainsKey(nmbAlbum))
            {
                if (listeAlbumsVisualiser.Last().Equals(listeAlbumsEmpruntable[0]))
                {
                    boutonSuivant.Visible = false;
                }
                else
                {
                    boutonSuivant.Visible = true;
                }
            }
            
        }


        #endregion


        private void UtilisateurUSEmprunt_MouseDown(object sender, MouseEventArgs e)
        {
            Point souris = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
            if(souris.X>=42 && souris.X <= 740)
            {
                int compteurCase = 0;
                bool trouveAlbum = false;
                foreach(KeyValuePair<int,int> ivv in caseY)
                {
                    if (!trouveAlbum)
                    {
                        if (souris.Y >= ivv.Key && souris.Y <= ivv.Value)
                        {
                            albumAEmprunter = listeAlbumsVisualiser[compteurCase];
                            
                            AfficheAlbumActuelle();
                        }
                        compteurCase++;
                    }
                }
            }
            CoordY.Text = souris.Y.ToString();
        }

        private void AfficheAlbumActuelle()
        {
            InfoNumero.Text = "N° : "+albumAEmprunter.CODE_ALBUM.ToString();
            InfoTitre.Text = albumAEmprunter.TITRE_ALBUM;
            InfoAnnee.Text = "Année : "+albumAEmprunter.ANNÉE_ALBUM.ToString();
            InfoEditeur.Text = "Editeur : "+albumAEmprunter.EDITEURS.NOM_EDITEUR;
            InfoGenre.Text = "Genre : "+albumAEmprunter.GENRES.LIBELLÉ_GENRE;
            InfoPrix.Text = "Prix : "+albumAEmprunter.PRIX_ALBUM.ToString()+" €";

        }
    }
}
