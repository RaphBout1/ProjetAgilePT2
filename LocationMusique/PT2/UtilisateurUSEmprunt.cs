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
    public partial class UtilisateurUSEmprunt : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Dictionary<string, ALBUMS> listeAlbumEmpruntable = new Dictionary<string, ALBUMS>();
        ALBUMS albumAEmprunter;
        ABONNÉS utilisateur;
        public UtilisateurUSEmprunt(ABONNÉS utilisateur)
        {
            InitializeComponent();
            initComboBoxEmprunt();
            this.utilisateur = utilisateur;
        }

        public void initComboBoxEmprunt()
        {
            var album = from a in musiqueSQL.ALBUMS
                        select a;
            foreach(ALBUMS a in album)
            {
                bool enEmprunt = false;
                foreach(EMPRUNTER e in a.EMPRUNTER)
                {
                    if (e.DATE_RETOUR == null) { enEmprunt = true; }
                }
                if (!enEmprunt) 
                {
                    listeAlbumEmpruntable.Add(a.TITRE_ALBUM,a);
                    comboBoxTitreAlbumAEmprunter.Items.Add(a.TITRE_ALBUM);
                }
            }
        }

        private void nUDNumeroAlbumAEmprunter_ValueChanged(object sender, EventArgs e)
        {
            bool numeroValide = false;
            foreach(KeyValuePair<string,ALBUMS> sa in listeAlbumEmpruntable)
            {
                if (sa.Value.CODE_ALBUM == nUDNumeroAlbumAEmprunter.Value)
                {
                    numeroValide = true;
                    albumAEmprunter = sa.Value;
                    comboBoxTitreAlbumAEmprunter.SelectedItem = albumAEmprunter.TITRE_ALBUM;
                }
            }
            if (!numeroValide)
            {
                MessageBox.Show("Numéro invalide");
            }
        }

        private void comboBoxTitreAlbumAEmprunter_SelectedIndexChanged(object sender, EventArgs e)
        {
            albumAEmprunter = listeAlbumEmpruntable[(string)comboBoxTitreAlbumAEmprunter.SelectedItem];
            nUDNumeroAlbumAEmprunter.Value = albumAEmprunter.CODE_ALBUM;
        }

        private void boutonEmprunterAlbumPrecis_Click(object sender, EventArgs e)
        {
            creerEmprunt(utilisateur.CODE_ABONNÉ, albumAEmprunter.CODE_ALBUM, monthCalendarClassique.SelectionStart, monthCalendarClassique.SelectionStart.AddDays(albumAEmprunter.GENRES.DÉLAI));
           

        }



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
    }
}
