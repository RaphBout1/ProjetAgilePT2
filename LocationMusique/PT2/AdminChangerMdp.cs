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
        public String nouveauMdp { get { return textBoxMdp.Text; } }
        public AdminChangerMdp()
        {
            InitializeComponent();
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxMdp.Text == textBoxMdpConfirm.Text && textBoxMdp.Text != "" && !textBoxMdp.Text.Contains(" "))
            {
                this.DialogResult = DialogResult.OK;
            }
            else { 
                MessageBox.Show("Les deux mots de passe sont différents.");
            }
        }
    }
}
