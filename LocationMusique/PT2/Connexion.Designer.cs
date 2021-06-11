
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connexion));
            this.pseudo = new System.Windows.Forms.TextBox();
            this.mdp = new System.Windows.Forms.TextBox();
            this.connectbutton = new System.Windows.Forms.Button();
            this.InscriptionButton = new System.Windows.Forms.Button();
            this.UtilisateurButton = new System.Windows.Forms.Button();
            this.AdminButton = new System.Windows.Forms.Button();
            this.afficherMdp = new System.Windows.Forms.CheckBox();
            this.pasAfficher = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pseudo
            // 
            this.pseudo.BackColor = System.Drawing.Color.Lavender;
            this.pseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pseudo.Location = new System.Drawing.Point(304, 208);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(554, 35);
            this.pseudo.TabIndex = 1;
            // 
            // mdp
            // 
            this.mdp.BackColor = System.Drawing.Color.Lavender;
            this.mdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdp.Location = new System.Drawing.Point(304, 314);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(554, 35);
            this.mdp.TabIndex = 2;
            this.mdp.UseSystemPasswordChar = true;
            // 
            // connectbutton
            // 
            this.connectbutton.BackColor = System.Drawing.Color.Transparent;
            this.connectbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectbutton.BackgroundImage")));
            this.connectbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectbutton.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.connectbutton.FlatAppearance.BorderSize = 0;
            this.connectbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectbutton.Location = new System.Drawing.Point(538, 624);
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Size = new System.Drawing.Size(407, 78);
            this.connectbutton.TabIndex = 3;
            this.connectbutton.UseVisualStyleBackColor = false;
            this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
            // 
            // InscriptionButton
            // 
            this.InscriptionButton.BackColor = System.Drawing.Color.Transparent;
            this.InscriptionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InscriptionButton.BackgroundImage")));
            this.InscriptionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InscriptionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InscriptionButton.FlatAppearance.BorderSize = 0;
            this.InscriptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InscriptionButton.Location = new System.Drawing.Point(565, 717);
            this.InscriptionButton.Margin = new System.Windows.Forms.Padding(4);
            this.InscriptionButton.Name = "InscriptionButton";
            this.InscriptionButton.Size = new System.Drawing.Size(355, 39);
            this.InscriptionButton.TabIndex = 4;
            this.InscriptionButton.Text = " ";
            this.InscriptionButton.UseVisualStyleBackColor = false;
            this.InscriptionButton.Click += new System.EventHandler(this.InscriptionButton_Click);
            // 
            // UtilisateurButton
            // 
            this.UtilisateurButton.Location = new System.Drawing.Point(831, 577);
            this.UtilisateurButton.Margin = new System.Windows.Forms.Padding(4);
            this.UtilisateurButton.Name = "UtilisateurButton";
            this.UtilisateurButton.Size = new System.Drawing.Size(100, 28);
            this.UtilisateurButton.TabIndex = 5;
            this.UtilisateurButton.Text = "Utilisateur";
            this.UtilisateurButton.UseVisualStyleBackColor = true;
            this.UtilisateurButton.Click += new System.EventHandler(this.UtilisateurButton_Click);
            // 
            // AdminButton
            // 
            this.AdminButton.Location = new System.Drawing.Point(538, 577);
            this.AdminButton.Margin = new System.Windows.Forms.Padding(4);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(100, 28);
            this.AdminButton.TabIndex = 6;
            this.AdminButton.Text = "Admin";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // afficherMdp
            // 
            this.afficherMdp.Appearance = System.Windows.Forms.Appearance.Button;
            this.afficherMdp.BackColor = System.Drawing.Color.Transparent;
            this.afficherMdp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("afficherMdp.BackgroundImage")));
            this.afficherMdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.afficherMdp.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.afficherMdp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.afficherMdp.FlatAppearance.BorderSize = 0;
            this.afficherMdp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.afficherMdp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.afficherMdp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afficherMdp.Location = new System.Drawing.Point(864, 310);
            this.afficherMdp.Name = "afficherMdp";
            this.afficherMdp.Size = new System.Drawing.Size(43, 43);
            this.afficherMdp.TabIndex = 19;
            this.afficherMdp.UseVisualStyleBackColor = false;
            this.afficherMdp.CheckedChanged += new System.EventHandler(this.afficherMdp_CheckedChanged);
            // 
            // pasAfficher
            // 
            this.pasAfficher.Appearance = System.Windows.Forms.Appearance.Button;
            this.pasAfficher.BackColor = System.Drawing.Color.Transparent;
            this.pasAfficher.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pasAfficher.BackgroundImage")));
            this.pasAfficher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pasAfficher.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasAfficher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pasAfficher.FlatAppearance.BorderSize = 0;
            this.pasAfficher.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.pasAfficher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pasAfficher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.pasAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasAfficher.Location = new System.Drawing.Point(864, 310);
            this.pasAfficher.Name = "pasAfficher";
            this.pasAfficher.Size = new System.Drawing.Size(43, 43);
            this.pasAfficher.TabIndex = 26;
            this.pasAfficher.UseVisualStyleBackColor = false;
            this.pasAfficher.Visible = false;
            this.pasAfficher.CheckedChanged += new System.EventHandler(this.pasAfficher_CheckedChanged);
            // 
            // Connexion
            // 
            this.AcceptButton = this.connectbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 862);
            this.Controls.Add(this.pasAfficher);
            this.Controls.Add(this.afficherMdp);
            this.Controls.Add(this.AdminButton);
            this.Controls.Add(this.UtilisateurButton);
            this.Controls.Add(this.InscriptionButton);
            this.Controls.Add(this.connectbutton);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.pseudo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.CheckBox afficherMdp;
        private System.Windows.Forms.CheckBox pasAfficher;
    }
}

