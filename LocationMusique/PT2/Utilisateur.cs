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
            //Recommandation();
            ActualiseListeEmprunté();
        }

        private void ActualiseListeEmprunté()
        {
            if (utilisateur != null)
            {
                foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
                {
                    ALBUMS a = e.ALBUMS;
                    listBoxConsultEmprunt.Items.Add(e);
                }
            }
            Refresh();
        }

        public void ProlongerEmprunt(int codeAlbum)
        {
            foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
            {
                ALBUMS a = e.ALBUMS;
                if (a.CODE_ALBUM == codeAlbum || codeAlbum == 9999)
                {
                    if (e.DATE_EMPRUNT.AddMonths(1).AddDays(a.GENRES.DÉLAI).CompareTo(e.DATE_RETOUR_ATTENDUE.AddMonths(1)) >= 0 && e.DATE_RETOUR == null)
                    {
                        var query = from l in musiqueSQL.EMPRUNTER where l.CODE_ALBUM == a.CODE_ALBUM select l;
                        EMPRUNTER x = query.First();
                        x.DATE_RETOUR_ATTENDUE = x.DATE_RETOUR_ATTENDUE.AddMonths(1);
                        e.dejaRenouvelé = true;
                        e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
                        MessageBox.Show("L'emprunt de l'album " + a.TITRE_ALBUM + " a bien été renouvelé.");
                        musiqueSQL.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Emprunt déjà prolongé !");
                    }
                }
            }

        }

        public void ProlongerTousEmprunts()
        {
            ProlongerEmprunt(9999);
        }

        #region Recommandation
        private void Recommandation()
        {
            listeGenreEmprunte.Clear();
            ListerGenreEmprunte();
            ListageRecommandeAlbum();
        }
        #region Calcule Recommandation
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

        private void ListageRecommandeAlbum()
        {
            Dictionary<int, ALBUMS> listeAlbum = new Dictionary<int, ALBUMS>();
            foreach (KeyValuePair<GENRES, int> gi in listeGenreEmprunte)
            {
                foreach (ALBUMS a in gi.Key.ALBUMS)
                {
                    listeAlbum.Add(a.EMPRUNTER.Count + (1000 * gi.Value), a);
                }
            }
            foreach (KeyValuePair<int, ALBUMS> ia in listeAlbum.OrderBy(importance => importance.Key))
            {
                listeAlbumsRecommande.Add(ia.Value);
            }
            foreach (ALBUMS b in listeAlbumsRecommande)
            {
                listBox1.Items.Add(b.TITRE_ALBUM);
                Refresh();
            }
        }
        #endregion

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            EMPRUNTER a = (EMPRUNTER)listBoxConsultEmprunt.SelectedItem;
            ProlongerEmprunt(a.CODE_ALBUM);
        }

        private void listBoxConsultEmprunt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxConsultEmprunt.SelectedItem != null)
            {
                button1.Enabled = true;
            }

            else
            {
                button1.Enabled = false;
            }
        }
    }
}
