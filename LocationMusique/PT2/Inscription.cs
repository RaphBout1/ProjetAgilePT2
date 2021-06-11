using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
        bool afficherMdpTexte;
        public Inscription()
        {
            InitializeComponent();
            chargerPays();
            passwordText.Visible = false;
            loginText.Visible = false;
            loginmdpImage.Visible = false;
            submit.Visible = false;
            retour.Visible = false;
            afficherMdpTexte = true;
            confirmerPicture.Visible = false;
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
        public static void abonner(string nom, string prenom, string pays, string login, string password, string passwordConfirmation)
        {
            if (!LongueurEntreeValide(nom) || !LongueurEntreeValide(prenom) || !LongueurEntreeValide(login) || !LongueurEntreeValide(password))
            {
                throw new InformationsInvalidesException("Aucun champ ne doit être laissé vide.");
            }
            int LoginCount = (from aa in musiqueSQL.ABONNÉS where aa.LOGIN_ABONNÉ == login select aa).Count();
            if (LoginCount != 0)
            {
                throw new InformationsInvalidesException("Login déjà existant. Veuillez entrer un login différent.");
            }
            if (!password.Equals(passwordConfirmation))
            {
                throw new InformationsInvalidesException("Les mots de passe ne correspondent pas.");
            }
            var paysInt = from p in musiqueSQL.PAYS where p.NOM_PAYS.ToLower() == pays.ToLower() select p.CODE_PAYS;
            if (paysInt.Count() > 0)
            {
                password = crypterMot(password);
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

        /// <summary>
        /// Vérifie qu'une chaîne de caractère a une longueur comprise entre 1 et 32 inclus
        /// </summary>
        /// <param name="entree">la chaîne de caractère dont la longueur est controllée</param>
        /// <returns>vrai si la chaîne de caractère respectent bien ces règles</returns>
        public static bool LongueurEntreeValide(string entree)
        {
            if (String.IsNullOrEmpty(entree) || entree.Length > 32)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Génère le hachage de cryptage par la méthode HMACSHA1, le sel de cryptage est fixe
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String crypterMot(String data)
        {
            byte[] salt = new byte[128 / 8];
            var saltnbr = 1234567891234567;
            BitConverter.GetBytes(saltnbr);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: data,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 36 / 8));
            return hashed;
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
                abonner(nomText.Text, prenomText.Text, paysComboBox.Text, loginText.Text, passwordText.Text, confirmationMdpBox.Text);
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
            confirmationMdpBox.Visible = true;
            afficherMdp.Visible = true;
            confirmerPicture.Visible = true;
            affichemdp2.Visible = true;
            pasAfficher.Visible = true;
            pasAfficher2.Visible = true;
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
            confirmationMdpBox.Visible = false;
            afficherMdp.Visible = false;
            confirmerPicture.Visible = false;
            affichemdp2.Visible = false;
            pasAfficher.Visible = false;
            pasAfficher2.Visible = false;
        }

        private void afficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            passwordText.UseSystemPasswordChar = false;
            afficherMdp.Visible = false;
            pasAfficher.Visible = true;

        }

        private void affichemdp2_CheckedChanged(object sender, EventArgs e)
        {
            confirmationMdpBox.UseSystemPasswordChar = false;
            affichemdp2.Visible = false;
            pasAfficher2.Visible = true;
        }

        private void pasAfficher_CheckedChanged(object sender, EventArgs e)
        {
            passwordText.UseSystemPasswordChar = true;
            afficherMdp.Visible = true;
            pasAfficher.Visible = false;

        }

        private void pasAfficher2_CheckedChanged(object sender, EventArgs e)
        {
            confirmationMdpBox.UseSystemPasswordChar = true;
            affichemdp2.Visible = true;
            pasAfficher2.Visible = false;
        }
    }
}
