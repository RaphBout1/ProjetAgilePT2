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
        public RajoutVinyle()
        {
            InitializeComponent();
        }

        private bool VerifPresenceNecessaire()
        {
            bool toutPresent = true;
            if (textBoxTitre.Text == null) { toutPresent = false; }
            else if (nUDPrix.Value == 0) { toutPresent = false; }
            else if (textBoxAlle.Text == null) { toutPresent = false; }
            else if (pictureBoxPochette.Image == null) { toutPresent = false; }
            return toutPresent;
        }

        private void boutonAjouter_Click(object sender, EventArgs e)
        {
            if (VerifPresenceNecessaire())
            {
                MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
                ALBUMS ajout = new ALBUMS();
                if (comboBoxEditeur.SelectedItem != null) { ajout.EDITEURS = (EDITEURS)comboBoxEditeur.SelectedItem; }
                if (comboBoxGenre.SelectedItem != null) { ajout.GENRES = (GENRES)comboBoxGenre.SelectedItem; }
                if (nUDAnneeParution.Value != 0) { ajout.ANNÉE_ALBUM = (int)nUDAnneeParution.Value; }
                ajout.TITRE_ALBUM = textBoxTitre.Text;
                ajout.PRIX_ALBUM = (int)nUDPrix.Value;
                ajout.ALLÉE_ALBUM = textBoxAlle.Text;
                ajout.CASIER_ALBUM = (int)nUDCasier.Value;
                using (var ms = new MemoryStream())
                {
                    pictureBoxPochette.Image.Save(ms, pictureBoxPochette.Image.RawFormat);
                    ajout.POCHETTE = ms.ToArray();
                }
                musiqueSQL.ALBUMS.Add(ajout);
                musiqueSQL.SaveChanges();
            }
        }
    }
}
