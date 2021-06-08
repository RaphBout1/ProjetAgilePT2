
namespace PT2
{
    partial class Connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pseudo = new System.Windows.Forms.TextBox();
            this.mdp = new System.Windows.Forms.TextBox();
            this.connectbutton = new System.Windows.Forms.Button();
            this.InscriptionButton = new System.Windows.Forms.Button();
            this.UtilisateurButton = new System.Windows.Forms.Button();
            this.AdminButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pseudo
            // 
            this.pseudo.Location = new System.Drawing.Point(31, 88);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(100, 20);
            this.pseudo.TabIndex = 1;
            // 
            // mdp
            // 
            this.mdp.Location = new System.Drawing.Point(31, 136);
            this.mdp.Name = "mdp";
            this.mdp.PasswordChar = '*';
            this.mdp.Size = new System.Drawing.Size(100, 20);
            this.mdp.TabIndex = 2;
            this.mdp.UseSystemPasswordChar = true;
            // 
            // connectbutton
            // 
            this.connectbutton.Location = new System.Drawing.Point(31, 182);
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Size = new System.Drawing.Size(75, 23);
            this.connectbutton.TabIndex = 3;
            this.connectbutton.Text = "Connexion";
            this.connectbutton.UseVisualStyleBackColor = true;
            // 
            // InscriptionButton
            // 
            this.InscriptionButton.BackColor = System.Drawing.Color.Transparent;
            this.InscriptionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InscriptionButton.BackgroundImage")));
            this.InscriptionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InscriptionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InscriptionButton.FlatAppearance.BorderSize = 0;
            this.InscriptionButton.Location = new System.Drawing.Point(755, 872);
            this.InscriptionButton.Margin = new System.Windows.Forms.Padding(4);
            this.InscriptionButton.Name = "InscriptionButton";
            this.InscriptionButton.Size = new System.Drawing.Size(375, 51);
            this.InscriptionButton.TabIndex = 4;
            this.InscriptionButton.Text = " ";
            this.InscriptionButton.UseVisualStyleBackColor = false;
            this.InscriptionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // UtilisateurButton
            // 
            this.UtilisateurButton.Location = new System.Drawing.Point(697, 693);
            this.UtilisateurButton.Margin = new System.Windows.Forms.Padding(4);
            this.UtilisateurButton.Name = "UtilisateurButton";
            this.UtilisateurButton.Size = new System.Drawing.Size(100, 28);
            this.UtilisateurButton.TabIndex = 5;
            this.UtilisateurButton.Text = "Utilisateur";
            this.UtilisateurButton.UseVisualStyleBackColor = true;
            this.UtilisateurButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminButton
            // 
            this.AdminButton.Location = new System.Drawing.Point(1107, 706);
            this.AdminButton.Margin = new System.Windows.Forms.Padding(4);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(100, 28);
            this.AdminButton.TabIndex = 6;
            this.AdminButton.Text = "Admin";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1982, 1078);
            this.Controls.Add(this.AdminButton);
            this.Controls.Add(this.UtilisateurButton);
            this.Controls.Add(this.InscriptionButton);
            this.Controls.Add(this.connectbutton);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.pseudo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Connexion";
            this.Text = "Discothèque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pseudo;
        private System.Windows.Forms.TextBox mdp;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.Button InscriptionButton;
        private System.Windows.Forms.Button UtilisateurButton;
        private System.Windows.Forms.Button AdminButton;
    }
}

