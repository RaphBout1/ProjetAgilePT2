﻿using System;
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

        public void ProlongerEmprunt(EMPRUNTER em)
        {
            if (em != null && em.DATE_RETOUR == null)
            {
                if (em.DATE_EMPRUNT.AddDays(em.ALBUMS.GENRES.DÉLAI).CompareTo(em.DATE_RETOUR_ATTENDUE) == 0 && em.DATE_RETOUR == null)
                {
                    em.DATE_RETOUR_ATTENDUE = em.DATE_RETOUR_ATTENDUE.AddMonths(1);
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
                listBox1.Items.Add(b.TITRE_ALBUM);
                Refresh();
            }
        }
        #endregion

        #endregion

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

        private void prolongerTousButton_Click(object sender, EventArgs e)
        {
            foreach (EMPRUNTER em in utilisateur.EMPRUNTER)
            {
                try
                {
                    ProlongerEmprunt(em);
                }
                catch (Exception ex)
                {

                }
            }
            MessageBox.Show("Tous vos emprunts prolongeables ont été prolongés d'un mois.");
        }

        private void prolonger1Button_Click(object sender, EventArgs e)
        {
            try
            {
                EMPRUNTER emprunt = (EMPRUNTER)listBoxConsultEmprunt.SelectedItem;
                ProlongerEmprunt(emprunt);
                MessageBox.Show("L'emprunt de l'album " + emprunt.ALBUMS.TITRE_ALBUM + " a bien été prolongé.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
