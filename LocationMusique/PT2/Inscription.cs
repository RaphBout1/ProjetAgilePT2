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
                if (nom.Length < 1 || prenom.Length < 1)
                {
                    throw new InformationsInvalidesException("les champs nom et prénom ne doivent pas être vides.");
                }
                int LoginCount = (from aa in musiqueSQL.ABONNÉS where aa.LOGIN_ABONNÉ == login select aa).Count();
                if (LoginCount != 0)
                {
                    throw new InformationsInvalidesException("login déjà existant. Veuillez entrer un login différent.");
                }
                var paysInt = from p in musiqueSQL.PAYS where p.NOM_PAYS.ToLower() == pays.ToLower() select p.CODE_PAYS;
                if (paysInt.Count() > 0)
                {
                    ABONNÉS a = new ABONNÉS
                    {
                        CODE_PAYS = paysInt.First(),
                        LOGIN_ABONNÉ = login,
                        NOM_ABONNÉ = nom,
                        PRÉNOM_ABONNÉ = prenom,
                        PASSWORD_ABONNÉ = password
                    };
                    musiqueSQL.ABONNÉS.Add(a);
                    musiqueSQL.SaveChanges();
                }
                else
                {
                    throw new InformationsInvalidesException("Pays inexistant.");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString() + Environment.NewLine + "Annulation.");
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            abonner(nomText.Text, prenomText.Text, paysText.Text, loginText.Text, passwordText.Text);
        }
    }
}
