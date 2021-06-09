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
    /// <summary>
    /// Gère l'inscription dans la base de donnée en tant qu'abonné des utilisateur
    /// </summary>
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
            chargerPays();
            passwordText.Visible = false;
            loginText.Visible = false;
            loginmdpImage.Visible = false;
            submit.Visible = false;
            retour.Visible = false;
        }

        /// <summary>
        /// Ajoute tous les pays contenus dans la base de donnée par ordre alphabétique à paysComboBox
        /// </summary>
        public void chargerPays()
        {
            var pays = from p in musiqueSQL.PAYS orderby p.NOM_PAYS select p;
            foreach (var p in pays)
            {
                paysComboBox.Items.Add(p.ToString().Trim());
            }
        }

        static MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();

        /**
         * Crée un nouvel abonné dans la base si les informations données sont valides
         */
        public static void abonner(string nom, string prenom, string pays, string login, string password)
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

        /**
         * Lance la création d'un nouvel abonné à partir des informations du formulaire
         */
        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginText.Text.ToLower().Contains("test"))
                {
                    throw new InformationsInvalidesException("L'identifiant ne doit pas contenir le mot \"test\"");
                }
                abonner(nomText.Text, prenomText.Text, paysComboBox.Text, loginText.Text, passwordText.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + Environment.NewLine + "Annulation.");
            }
        }

        private void suiteButton_Click(object sender, EventArgs e)
        {
            nomPrenomPaysImage.Visible = false;
            paysComboBox.Visible = false;
            prenomText.Visible = false;
            nomText.Visible = false;
            passwordText.Visible = true;
            loginText.Visible = true;
            loginmdpImage.Visible = true;
            suiteButton.Visible = false;
            submit.Visible = true;
            retour.Visible = true;
            cancelButton.Visible = false;

        }

        private void retour_Click(object sender, EventArgs e)
        {
            nomPrenomPaysImage.Visible = true;
            paysComboBox.Visible = true;
            prenomText.Visible = true;
            nomText.Visible = true;
            passwordText.Visible = false;
            loginText.Visible = false;
            loginmdpImage.Visible = false;
            suiteButton.Visible = true;
            submit.Visible = false;
            retour.Visible = false;
            cancelButton.Visible = true;
            passwordText.Visible = false;
            loginText.Visible = false;
            loginmdpImage.Visible = false;
            submit.Visible = false;
            retour.Visible = false;
        }
    }
}
