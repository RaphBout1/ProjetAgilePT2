
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
            this.listBoxConsultEmprunt = new System.Windows.Forms.ListBox();
            this.nom = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxConsultEmprunt
            // 
            this.listBoxConsultEmprunt.FormattingEnabled = true;
            this.listBoxConsultEmprunt.Location = new System.Drawing.Point(13, 13);
            this.listBoxConsultEmprunt.Name = "listBoxConsultEmprunt";
            this.listBoxConsultEmprunt.Size = new System.Drawing.Size(120, 95);
            this.listBoxConsultEmprunt.TabIndex = 0;
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Location = new System.Drawing.Point(726, 13);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(27, 13);
            this.nom.TabIndex = 1;
            this.nom.Text = "nom";
            // 
            // prenom
            // 
            this.prenom.AutoSize = true;
            this.prenom.Location = new System.Drawing.Point(726, 60);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(42, 13);
            this.prenom.TabIndex = 2;
            this.prenom.Text = "prenom";
            // 
            // Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.listBoxConsultEmprunt);
            this.Name = "Utilisateur";
            this.Text = "Utilisateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConsultEmprunt;
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label prenom;
    }
}