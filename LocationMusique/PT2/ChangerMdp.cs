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
    public partial class ChangerMdp : Form
    {
        public string nouveauMdp { get { return Inscription.crypterMot(textBoxMdp.Text); } }
        private bool estAdmin { get; set; }
        private ABONNÉS utilisateur { get; set; }
        public ChangerMdp(ABONNÉS abonne)
        {
            InitializeComponent();
            initialisationUtilisateur(abonne);
        }

        /// <summary>
        /// Gère certaines fonctionnalités en fonction de si l'utilisateur passé en paramètre est l'administrateur ou non.
        /// </summary>
        /// <param name="abonne">L'abonne ayant appelé la création du form</param>
        private void initialisationUtilisateur(ABONNÉS abonne)
        {
            utilisateur = abonne;
            estAdmin = "admin".Equals((utilisateur.LOGIN_ABONNÉ).Trim());
            labelAncien.Visible = !estAdmin;
            AncienMdpTextBox.Visible = !estAdmin;
            pasAfficher1.Visible = !estAdmin;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                confirmation();
            }
            catch (InformationsInvalidesException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// vérifie si le formulaire pour changer de mot de passe est correctement rempli et répond en conséquence
        /// </summary>
        private void confirmation()
        {
            if (!textBoxMdp.Text.Equals(textBoxMdpConfirm.Text))
            {
                throw new InformationsInvalidesException("Les deux mots de passe sont différents.");
            }
            if (!Inscription.LongueurEntreeValide(textBoxMdp.Text))
            {
                throw new InformationsInvalidesException("La longueur du mot de passe doit être comprise entre 1 et 32 caractères.");
            }
            else
            {
                if (!estAdmin)
                {
                    if (!Inscription.crypterMot(AncienMdpTextBox.Text).Equals(utilisateur.PASSWORD_ABONNÉ.Trim()))
                    {
                        throw new InformationsInvalidesException("Le mot de passe donné ne correspond pas à l'ancien mot de passe.");
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Change l'affichage du mot de passe (nouveau) ainsi que sa confirmation avec des étoiles ou non
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nvMdpCheckBox_Click(object sender, EventArgs e)
        {
            textBoxMdp.UseSystemPasswordChar = !textBoxMdp.UseSystemPasswordChar;
            textBoxMdpConfirm.UseSystemPasswordChar = !textBoxMdpConfirm.UseSystemPasswordChar;


        }
/// <summary>
        /// Change l'affichage du mot de passe (ancien) avec des étoiles ou non
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            pasAfficher1.Visible = true;
            AncienMdpTextBox.UseSystemPasswordChar = true;
            afficherMdp.Visible = false;
        }

        private void affichermdp2_CheckedChanged(object sender, EventArgs e)
        {
            pasAfficher2.Visible = true;
            textBoxMdp.UseSystemPasswordChar = true;
            affichermdp2.Visible = false;
        }

        private void affichermdp3_CheckedChanged(object sender, EventArgs e)
        {
            pasAfficher3.Visible = true;
            textBoxMdpConfirm.UseSystemPasswordChar = true;
            affichermdp3.Visible = false;
        }

        private void pasAfficher1_CheckedChanged(object sender, EventArgs e)
        {
            AncienMdpTextBox.UseSystemPasswordChar = false;
            afficherMdp.Visible = true;
            pasAfficher1.Visible = false;
        }

        private void pasAfficher2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMdp.UseSystemPasswordChar = false;
            affichermdp2.Visible = true;
            pasAfficher2.Visible = false;
        }

        private void pasAfficher3_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMdpConfirm.UseSystemPasswordChar = false;
            affichermdp3.Visible = true;
            pasAfficher3.Visible = false;
        }
    }
}
