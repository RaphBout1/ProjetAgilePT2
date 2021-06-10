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
    public partial class AdminChangerMdp : Form
    {
        public string nouveauMdp { get { return textBoxMdp.Text; } }
        public AdminChangerMdp()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                confirmation();
            } catch (InformationsInvalidesException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// vérifie si le formulaire pour changer de mot de passe est correctement rempli et répond en conséquence
        /// </summary>
        private void confirmation()
        {
            if (Inscription.LongueurEntreeValide(textBoxMdp.Text) && textBoxMdp.Text.Equals(textBoxMdpConfirm.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                throw new InformationsInvalidesException("Les deux mots de passe sont différents.");
            }
        }
    }
}
