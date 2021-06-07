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
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
        }

        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        /**
         * crée un nouvel abonné dans la base si les informations données sont valides
         */
        public void abonner(string nom, string prenom, string pays, string login, string password)
        {
            try
            {
                if (nom.Length == 0 || prenom.Length == 0)
                {
                    throw new InformationsInvalidesException("les champs nom et prénom ne doivent pas être vides");
                }
                int LoginCount = (from aa in musiqueSQL.ABONNÉS where aa.LOGIN_ABONNÉ == login select aa).Count();
                if (LoginCount != 0)
                {
                    throw new InformationsInvalidesException("login déjà existant. Veuillez entrer un login différent.");
                }
                int paysInt = (from p in musiqueSQL.PAYS where p.NOM_PAYS == pays select p.CODE_PAYS).First();

                ABONNÉS a = new ABONNÉS
                {
                    CODE_PAYS = paysInt,
                    LOGIN_ABONNÉ = login,
                    NOM_ABONNÉ = nom,
                    PRÉNOM_ABONNÉ = prenom,
                    PASSWORD_ABONNÉ = password
                };
                musiqueSQL.ABONNÉS.Add(a);
                musiqueSQL.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            abonner(nom.Text, prenom.Text, pays.Text, login.Text, password.Text);
        }
    }
}
