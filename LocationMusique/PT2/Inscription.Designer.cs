﻿
namespace PT2
{
    partial class Inscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginText = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.nomButton = new System.Windows.Forms.TextBox();
            this.prenomText = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.Label();
            this.pays = new System.Windows.Forms.Label();
            this.paysText = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(396, 87);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(100, 20);
            this.loginText.TabIndex = 0;
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Location = new System.Drawing.Point(140, 87);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(29, 13);
            this.login.TabIndex = 1;
            this.login.Text = "login";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(143, 147);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(52, 13);
            this.password.TabIndex = 2;
            this.password.Text = "password";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(396, 139);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(100, 20);
            this.passwordText.TabIndex = 3;
            // 
            // nomButton
            // 
            this.nomButton.Location = new System.Drawing.Point(396, 192);
            this.nomButton.Name = "nomButton";
            this.nomButton.Size = new System.Drawing.Size(100, 20);
            this.nomButton.TabIndex = 4;
            // 
            // prenomText
            // 
            this.prenomText.Location = new System.Drawing.Point(396, 247);
            this.prenomText.Name = "prenomText";
            this.prenomText.Size = new System.Drawing.Size(100, 20);
            this.prenomText.TabIndex = 5;
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Location = new System.Drawing.Point(143, 192);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(27, 13);
            this.nom.TabIndex = 6;
            this.nom.Text = "nom";
            // 
            // prenom
            // 
            this.prenom.AutoSize = true;
            this.prenom.Location = new System.Drawing.Point(143, 247);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(42, 13);
            this.prenom.TabIndex = 7;
            this.prenom.Text = "prenom";
            // 
            // pays
            // 
            this.pays.AutoSize = true;
            this.pays.Location = new System.Drawing.Point(143, 306);
            this.pays.Name = "pays";
            this.pays.Size = new System.Drawing.Size(29, 13);
            this.pays.TabIndex = 8;
            this.pays.Text = "pays";
            // 
            // paysText
            // 
            this.paysText.Location = new System.Drawing.Point(396, 306);
            this.paysText.Name = "paysText";
            this.paysText.Size = new System.Drawing.Size(100, 20);
            this.paysText.TabIndex = 9;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(651, 359);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 10;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.paysText);
            this.Controls.Add(this.pays);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.prenomText);
            this.Controls.Add(this.nomButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.loginText);
            this.Name = "Inscription";
            this.Text = "Inscription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox nomButton;
        private System.Windows.Forms.TextBox prenomText;
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label prenom;
        private System.Windows.Forms.Label pays;
        private System.Windows.Forms.TextBox paysText;
        private System.Windows.Forms.Button submit;
    }
}