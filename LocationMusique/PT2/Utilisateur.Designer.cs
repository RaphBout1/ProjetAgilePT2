
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
            this.nom = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.Label();
            this.prolonger1Button = new System.Windows.Forms.Button();
            this.prolongerTousButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rendreButton = new System.Windows.Forms.Button();
            this.MAJButton = new System.Windows.Forms.Button();
            this.afficherEmprunts = new System.Windows.Forms.Button();
            this.afficherRecommandations = new System.Windows.Forms.Button();
            this.quitter = new System.Windows.Forms.Button();
            this.retard = new System.Windows.Forms.Button();
            this.enCours = new System.Windows.Forms.Button();
            this.listViewConsultation = new System.Windows.Forms.ListView();
            this.utilisateurChangerMdp = new System.Windows.Forms.Button();
            this.boutonPageRetour = new System.Windows.Forms.Button();
            this.boutonPageSuivant = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.prolonger1Button.BackColor = System.Drawing.Color.Transparent;
            this.prolonger1Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prolonger1Button.BackgroundImage")));
            this.prolonger1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prolonger1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolonger1Button.Enabled = false;
            this.prolonger1Button.FlatAppearance.BorderSize = 0;
            this.prolonger1Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.prolonger1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolonger1Button.Location = new System.Drawing.Point(1191, 675);
            this.prolonger1Button.Name = "prolonger1Button";
            this.prolonger1Button.Size = new System.Drawing.Size(338, 68);
            this.prolonger1Button.TabIndex = 4;
            this.prolonger1Button.UseVisualStyleBackColor = false;
            this.prolonger1Button.Click += new System.EventHandler(this.prolonger1Button_Click);
            // 
            // prolongerTousButton
            // 
            this.prolongerTousButton.BackColor = System.Drawing.Color.Transparent;
            this.prolongerTousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prolongerTousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolongerTousButton.FlatAppearance.BorderSize = 0;
            this.prolongerTousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.prolongerTousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolongerTousButton.ForeColor = System.Drawing.Color.Transparent;
            this.prolongerTousButton.Image = ((System.Drawing.Image)(resources.GetObject("prolongerTousButton.Image")));
            this.prolongerTousButton.Location = new System.Drawing.Point(645, 682);
            this.prolongerTousButton.Name = "prolongerTousButton";
            this.prolongerTousButton.Size = new System.Drawing.Size(338, 55);
            this.prolongerTousButton.TabIndex = 5;
            this.prolongerTousButton.UseVisualStyleBackColor = false;
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
            this.button1.Location = new System.Drawing.Point(39, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 60);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rendreButton
            // 
            this.rendreButton.BackColor = System.Drawing.Color.Transparent;
            this.rendreButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rendreButton.BackgroundImage")));
            this.rendreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rendreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rendreButton.FlatAppearance.BorderSize = 0;
            this.rendreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.rendreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rendreButton.Location = new System.Drawing.Point(288, 12);
            this.rendreButton.Name = "rendreButton";
            this.rendreButton.Size = new System.Drawing.Size(351, 89);
            this.rendreButton.TabIndex = 7;
            this.rendreButton.UseVisualStyleBackColor = false;
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
            this.afficherEmprunts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.afficherEmprunts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afficherEmprunts.Location = new System.Drawing.Point(155, 300);
            this.afficherEmprunts.Name = "afficherEmprunts";
            this.afficherEmprunts.Size = new System.Drawing.Size(311, 62);
            this.afficherEmprunts.TabIndex = 9;
            this.afficherEmprunts.UseVisualStyleBackColor = false;
            this.afficherEmprunts.Click += new System.EventHandler(this.afficherEmprunts_Click);
            // 
            // afficherRecommandations
            // 
            this.afficherRecommandations.BackColor = System.Drawing.Color.Transparent;
            this.afficherRecommandations.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("afficherRecommandations.BackgroundImage")));
            this.afficherRecommandations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.afficherRecommandations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.afficherRecommandations.FlatAppearance.BorderSize = 0;
            this.afficherRecommandations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.afficherRecommandations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afficherRecommandations.Location = new System.Drawing.Point(155, 479);
            this.afficherRecommandations.Name = "afficherRecommandations";
            this.afficherRecommandations.Size = new System.Drawing.Size(341, 83);
            this.afficherRecommandations.TabIndex = 10;
            this.afficherRecommandations.UseVisualStyleBackColor = false;
            this.afficherRecommandations.Click += new System.EventHandler(this.afficherRecommandations_Click);
            // 
            // quitter
            // 
            this.quitter.BackColor = System.Drawing.Color.Transparent;
            this.quitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitter.BackgroundImage")));
            this.quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitter.FlatAppearance.BorderSize = 0;
            this.quitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitter.Location = new System.Drawing.Point(39, 701);
            this.quitter.Name = "quitter";
            this.quitter.Size = new System.Drawing.Size(346, 70);
            this.quitter.TabIndex = 11;
            this.quitter.UseVisualStyleBackColor = false;
            // 
            // retard
            // 
            this.retard.BackColor = System.Drawing.Color.Transparent;
            this.retard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("retard.BackgroundImage")));
            this.retard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retard.FlatAppearance.BorderSize = 0;
            this.retard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.retard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retard.Location = new System.Drawing.Point(1191, 743);
            this.retard.Name = "retard";
            this.retard.Size = new System.Drawing.Size(338, 79);
            this.retard.TabIndex = 12;
            this.retard.UseVisualStyleBackColor = false;
            this.retard.Click += new System.EventHandler(this.retard_Click);
            // 
            // enCours
            // 
            this.enCours.BackColor = System.Drawing.Color.Transparent;
            this.enCours.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enCours.BackgroundImage")));
            this.enCours.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enCours.FlatAppearance.BorderSize = 0;
            this.enCours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.enCours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enCours.Location = new System.Drawing.Point(645, 743);
            this.enCours.Name = "enCours";
            this.enCours.Size = new System.Drawing.Size(338, 79);
            this.enCours.TabIndex = 13;
            this.enCours.UseVisualStyleBackColor = false;
            this.enCours.Click += new System.EventHandler(this.enCours_Click);
            // 
            // listViewConsultation
            // 
            this.listViewConsultation.HideSelection = false;
            this.listViewConsultation.Location = new System.Drawing.Point(645, 114);
            this.listViewConsultation.MultiSelect = false;
            this.listViewConsultation.Name = "listViewConsultation";
            this.listViewConsultation.Size = new System.Drawing.Size(839, 533);
            this.listViewConsultation.TabIndex = 14;
            this.listViewConsultation.UseCompatibleStateImageBehavior = false;
            this.listViewConsultation.SelectedIndexChanged += new System.EventHandler(this.listViewConsultation_SelectedIndexChanged);
            // 
            // utilisateurChangerMdp
            // 
            this.utilisateurChangerMdp.Location = new System.Drawing.Point(223, 599);
            this.utilisateurChangerMdp.Name = "utilisateurChangerMdp";
            this.utilisateurChangerMdp.Size = new System.Drawing.Size(145, 23);
            this.utilisateurChangerMdp.TabIndex = 18;
            this.utilisateurChangerMdp.Text = "changer mot de passe";
            this.utilisateurChangerMdp.UseVisualStyleBackColor = true;
            this.utilisateurChangerMdp.Click += new System.EventHandler(this.utilisateurChangerMdp_Click);
            // 
            // boutonPageRetour
            // listViewConsultation
            // 
            this.boutonPageRetour.Location = new System.Drawing.Point(1497, 624);
            this.boutonPageRetour.Name = "boutonPageRetour";
            this.boutonPageRetour.Size = new System.Drawing.Size(75, 23);
            this.boutonPageRetour.TabIndex = 19;
            this.boutonPageRetour.Text = "Retour";
            this.boutonPageRetour.UseVisualStyleBackColor = true;
            this.boutonPageRetour.Visible = false;
            this.boutonPageRetour.Click += new System.EventHandler(this.boutonPageRetour_Click);
            // 
            // boutonPageSuivant
            // 
            this.boutonPageSuivant.Location = new System.Drawing.Point(1497, 554);
            this.boutonPageSuivant.Name = "boutonPageSuivant";
            this.boutonPageSuivant.Size = new System.Drawing.Size(75, 23);
            this.boutonPageSuivant.TabIndex = 20;
            this.boutonPageSuivant.Text = "Suivant";
            this.boutonPageSuivant.UseVisualStyleBackColor = true;
            this.boutonPageSuivant.Visible = false;
            this.boutonPageSuivant.Click += new System.EventHandler(this.boutonPageSuivant_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.BackColor = System.Drawing.Color.Transparent;
            this.labelPage.Location = new System.Drawing.Point(1503, 599);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(16, 13);
            this.labelPage.TabIndex = 21;
            this.labelPage.Text = "   ";
            // 
            // utilisateurChangerMdp
            // 
            this.utilisateurChangerMdp.Location = new System.Drawing.Point(223, 599);
            this.utilisateurChangerMdp.Name = "utilisateurChangerMdp";
            this.utilisateurChangerMdp.Size = new System.Drawing.Size(145, 23);
            this.utilisateurChangerMdp.TabIndex = 18;
            this.utilisateurChangerMdp.Text = "changer mot de passe";
            this.utilisateurChangerMdp.UseVisualStyleBackColor = true;
            this.utilisateurChangerMdp.Click += new System.EventHandler(this.utilisateurChangerMdp_Click);
            // 
            // Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.boutonPageSuivant);
            this.Controls.Add(this.boutonPageRetour);
            this.Controls.Add(this.utilisateurChangerMdp);
            this.Controls.Add(this.listViewConsultation);
            this.Controls.Add(this.enCours);
            this.Controls.Add(this.retard);
            this.Controls.Add(this.quitter);
            this.Controls.Add(this.afficherRecommandations);
            this.Controls.Add(this.afficherEmprunts);
            this.Controls.Add(this.MAJButton);
            this.Controls.Add(this.rendreButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prolongerTousButton);
            this.Controls.Add(this.prolonger1Button);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.DoubleBuffered = true;
            this.Name = "Utilisateur";
            this.Text = "Utilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label prenom;
        private System.Windows.Forms.Button prolonger1Button;
        private System.Windows.Forms.Button prolongerTousButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rendreButton;
        private System.Windows.Forms.Button MAJButton;
        private System.Windows.Forms.Button afficherEmprunts;
        private System.Windows.Forms.Button afficherRecommandations;
        private System.Windows.Forms.Button quitter;
        private System.Windows.Forms.Button retard;
        private System.Windows.Forms.Button enCours;
        private System.Windows.Forms.ListView listViewConsultation;
        private System.Windows.Forms.Button utilisateurChangerMdp;
        private System.Windows.Forms.Button boutonPageRetour;
        private System.Windows.Forms.Button boutonPageSuivant;
        private System.Windows.Forms.Label labelPage;
    }
}