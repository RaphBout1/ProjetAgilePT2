
namespace PT2
{
    partial class Utilisateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utilisateur));
            this.listBoxConsultEmprunt = new System.Windows.Forms.ListBox();
            this.nom = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.Label();
            this.prolonger1Button = new System.Windows.Forms.Button();
            this.prolongerTousButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rendreButton = new System.Windows.Forms.Button();
            this.MAJButton = new System.Windows.Forms.Button();
            this.afficherEmprunts = new System.Windows.Forms.Button();
            this.afficherRecommandations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxConsultEmprunt
            // 
            this.listBoxConsultEmprunt.FormattingEnabled = true;
            this.listBoxConsultEmprunt.HorizontalScrollbar = true;
            this.listBoxConsultEmprunt.Location = new System.Drawing.Point(782, 118);
            this.listBoxConsultEmprunt.Name = "listBoxConsultEmprunt";
            this.listBoxConsultEmprunt.Size = new System.Drawing.Size(374, 342);
            this.listBoxConsultEmprunt.TabIndex = 0;
            this.listBoxConsultEmprunt.SelectedIndexChanged += new System.EventHandler(this.listBoxConsultEmprunt_SelectedIndexChanged);
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.BackColor = System.Drawing.Color.Transparent;
            this.nom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nom.Location = new System.Drawing.Point(8, 9);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(51, 24);
            this.nom.TabIndex = 1;
            this.nom.Text = "nom";
            // 
            // prenom
            // 
            this.prenom.AutoSize = true;
            this.prenom.BackColor = System.Drawing.Color.Transparent;
            this.prenom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.prenom.Location = new System.Drawing.Point(8, 33);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(82, 24);
            this.prenom.TabIndex = 2;
            this.prenom.Text = "prenom";
            // 
            // prolonger1Button
            // 
            this.prolonger1Button.Enabled = false;
            this.prolonger1Button.Location = new System.Drawing.Point(1051, 568);
            this.prolonger1Button.Name = "prolonger1Button";
            this.prolonger1Button.Size = new System.Drawing.Size(105, 55);
            this.prolonger1Button.TabIndex = 4;
            this.prolonger1Button.Text = "Prolonger l\'emprunt";
            this.prolonger1Button.UseVisualStyleBackColor = true;
            this.prolonger1Button.Click += new System.EventHandler(this.prolonger1Button_Click);
            // 
            // prolongerTousButton
            // 
            this.prolongerTousButton.Location = new System.Drawing.Point(782, 568);
            this.prolongerTousButton.Name = "prolongerTousButton";
            this.prolongerTousButton.Size = new System.Drawing.Size(105, 55);
            this.prolongerTousButton.TabIndex = 5;
            this.prolongerTousButton.Text = "Prolonger TOUS les emprunts";
            this.prolongerTousButton.UseVisualStyleBackColor = true;
            this.prolongerTousButton.Click += new System.EventHandler(this.prolongerTousButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(70, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 62);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rendreButton
            // 
            this.rendreButton.Location = new System.Drawing.Point(172, 648);
            this.rendreButton.Name = "rendreButton";
            this.rendreButton.Size = new System.Drawing.Size(95, 57);
            this.rendreButton.TabIndex = 7;
            this.rendreButton.Text = "Rendre";
            this.rendreButton.UseVisualStyleBackColor = true;
            this.rendreButton.Click += new System.EventHandler(this.rendreButton_Click);
            // 
            // MAJButton
            // 
            this.MAJButton.Location = new System.Drawing.Point(12, 430);
            this.MAJButton.Name = "MAJButton";
            this.MAJButton.Size = new System.Drawing.Size(75, 23);
            this.MAJButton.TabIndex = 8;
            this.MAJButton.Text = "Mise à jour";
            this.MAJButton.UseVisualStyleBackColor = true;
            this.MAJButton.Click += new System.EventHandler(this.MAJButton_Click);
            // 
            // afficherEmprunts
            // 
            this.afficherEmprunts.BackColor = System.Drawing.Color.Transparent;
            this.afficherEmprunts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("afficherEmprunts.BackgroundImage")));
            this.afficherEmprunts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.afficherEmprunts.FlatAppearance.BorderSize = 0;
            this.afficherEmprunts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afficherEmprunts.Location = new System.Drawing.Point(142, 212);
            this.afficherEmprunts.Name = "afficherEmprunts";
            this.afficherEmprunts.Size = new System.Drawing.Size(283, 62);
            this.afficherEmprunts.TabIndex = 9;
            this.afficherEmprunts.UseVisualStyleBackColor = false;
            this.afficherEmprunts.Click += new System.EventHandler(this.afficherEmprunts_Click);
            // 
            // afficherRecommandations
            // 
            this.afficherRecommandations.Location = new System.Drawing.Point(308, 487);
            this.afficherRecommandations.Name = "afficherRecommandations";
            this.afficherRecommandations.Size = new System.Drawing.Size(126, 53);
            this.afficherRecommandations.TabIndex = 10;
            this.afficherRecommandations.Text = "Recommandations";
            this.afficherRecommandations.UseVisualStyleBackColor = true;
            this.afficherRecommandations.Click += new System.EventHandler(this.afficherRecommandations_Click);
            // 
            // Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.afficherRecommandations);
            this.Controls.Add(this.afficherEmprunts);
            this.Controls.Add(this.MAJButton);
            this.Controls.Add(this.rendreButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prolongerTousButton);
            this.Controls.Add(this.prolonger1Button);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.listBoxConsultEmprunt);
            this.DoubleBuffered = true;
            this.Name = "Utilisateur";
            this.Text = "Utilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConsultEmprunt;
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label prenom;
        private System.Windows.Forms.Button prolonger1Button;
        private System.Windows.Forms.Button prolongerTousButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rendreButton;
        private System.Windows.Forms.Button MAJButton;
        private System.Windows.Forms.Button afficherEmprunts;
        private System.Windows.Forms.Button afficherRecommandations;
    }
}