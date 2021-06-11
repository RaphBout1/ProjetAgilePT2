
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

        private void connectbutton_Click(object sender, EventArgs e)
        {
            ConnexionProcess();
        }

        private void ConnexionProcess()
        {
            String loginAbo = pseudo.Text;
            string mdpAbo = mdp.Text;
            string hashMdpAbo = Inscription.crypterMot(mdpAbo);
            var Abo = (from l in musiqueSQL.ABONNÉS where l.LOGIN_ABONNÉ.Equals(loginAbo) && l.PASSWORD_ABONNÉ.Equals(hashMdpAbo) select l);
            if (Abo.Count() > 0)
            {
                ABONNÉS aboconnecte = Abo.First();
                if (loginAbo.Equals("admin"))
                {
                    new Admin().ShowDialog();
                }
                else
                {
                    new Utilisateur(aboconnecte).ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Pseudo ou Mot de passe incorrect");
            }
            pseudo.Clear();
            mdp.Clear();
        }


        /// <summary>
        /// Affiche le mot de passe dans la textbox en clair ou non en fonction du statut de la checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            mdp.UseSystemPasswordChar = false;
            afficherMdp.Visible = false;
            pasAfficher.Visible = true;
        }

        private void pasAfficher_CheckedChanged(object sender, EventArgs e)
        {
            mdp.UseSystemPasswordChar = true;
            afficherMdp.Visible = true;
            pasAfficher.Visible = false;
        }
    }
}
