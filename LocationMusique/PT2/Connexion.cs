
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
    public partial class Connexion : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public Connexion()
        {
            InitializeComponent();

        }
            
        private void InscriptionButton_Click(object sender, EventArgs e)
        {
            new Inscription().ShowDialog();

        }
        private void UtilisateurButton_Click(object sender, EventArgs e)
        {
            ABONNÉS robert = (from l in musiqueSQL.ABONNÉS where l.LOGIN_ABONNÉ == "rbDLC" select l).First();
            Utilisateur utilisateur = new Utilisateur(robert);
            if (utilisateur.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
                       new Admin().ShowDialog();
        }
 
    }
}
