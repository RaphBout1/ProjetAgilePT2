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
    public partial class Form1 : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ABONNÉS robert;
            var listabo = from l in musiqueSQL.ABONNÉS where l.LOGIN_ABONNÉ == "Robert_DLC" select l;
            robert = listabo.First();
            Utilisateur utilisateur = new Utilisateur(robert);
            if (utilisateur.ShowDialog() == System.Windows.Forms.DialogResult.OK) { 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Inscription().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Admin().ShowDialog();
        }
    }
}
