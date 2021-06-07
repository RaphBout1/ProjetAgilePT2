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
    public partial class RajoutVinyle : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public RajoutVinyle()
        {
            InitializeComponent();
            initGenreEditeur();
        }

        private void initGenreEditeur()
        {
            var editeur = from e in musiqueSQL.EDITEURS
                          orderby e.NOM_EDITEUR
                          select e;
            foreach(EDITEURS e in editeur)
            {
                comboBoxEditeur.Items.Add(e);
            }
            var genre = from g in musiqueSQL.GENRES
                        orderby g.LIBELLÉ_GENRE
                        select g;
            foreach (GENRES g in genre)
            {
                comboBoxGenre.Items.Add(g);
            }
        }

        private bool VerifPresenceNecessaire()
        {
            bool toutPresent = true;
            if (textBoxTitre.Text == null) { toutPresent = false; }
            else if (nUDPrix.Value == 0) { toutPresent = false; }
            else if (textBoxAlle.Text == null) { toutPresent = false; }
            else if (comboBoxEditeur.SelectedItem == null) { toutPresent = false; }
            else if (comboBoxGenre.SelectedItem == null) { toutPresent = false; }
            return toutPresent;
        }

        private void boutonAjouter_Click(object sender, EventArgs e)
        {
            if (VerifPresenceNecessaire())
            {
                ALBUMS ajout = new ALBUMS();
                if (comboBoxEditeur.SelectedItem != null) 
                { 
                    ajout.EDITEURS = (EDITEURS)comboBoxEditeur.SelectedItem;
                    ajout.CODE_EDITEUR = ajout.EDITEURS.CODE_EDITEUR;
                }
                if (comboBoxGenre.SelectedItem != null) 
                { 
                    ajout.GENRES = (GENRES)comboBoxGenre.SelectedItem;
                    ajout.CODE_GENRE = ajout.GENRES.CODE_GENRE;
                }
                if (nUDAnneeParution.Value != 0) { ajout.ANNÉE_ALBUM = (int)nUDAnneeParution.Value; }
                ajout.TITRE_ALBUM = textBoxTitre.Text;
                ajout.PRIX_ALBUM = nUDPrix.Value;
                ajout.ALLÉE_ALBUM = textBoxAlle.Text;
                ajout.CASIER_ALBUM = (int)nUDCasier.Value;
                ajout.CODE_ALBUM = musiqueSQL.ALBUMS.Count()+1;
                if (pictureBoxPochette.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        pictureBoxPochette.Image.Save(ms, pictureBoxPochette.Image.RawFormat);
                        ajout.POCHETTE = ms.ToArray();
                    }
                }
                musiqueSQL.ALBUMS.Add(ajout);
                /*musiqueSQL.SaveChanges();
                MessageBox.Show("Importation du vinyle réussi");*/
                MessageBox.Show("Pour l'instant indisponible");
            }
            else
            {
                MessageBox.Show("Information manquante");
            }
        }
    }
}
