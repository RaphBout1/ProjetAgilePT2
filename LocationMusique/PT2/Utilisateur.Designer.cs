
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.prolonger1Button = new System.Windows.Forms.Button();
            this.prolongerTousButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxConsultEmprunt
            // 
            this.listBoxConsultEmprunt.FormattingEnabled = true;
            this.listBoxConsultEmprunt.HorizontalScrollbar = true;
            this.listBoxConsultEmprunt.Location = new System.Drawing.Point(13, 13);
            this.listBoxConsultEmprunt.Name = "listBoxConsultEmprunt";
            this.listBoxConsultEmprunt.Size = new System.Drawing.Size(311, 134);
            this.listBoxConsultEmprunt.TabIndex = 0;
            this.listBoxConsultEmprunt.SelectedIndexChanged += new System.EventHandler(this.listBoxConsultEmprunt_SelectedIndexChanged);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(391, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(174, 134);
            this.listBox1.TabIndex = 3;
            // 
            // prolonger1Button
            // 
            this.prolonger1Button.Enabled = false;
            this.prolonger1Button.Location = new System.Drawing.Point(13, 219);
            this.prolonger1Button.Name = "prolonger1Button";
            this.prolonger1Button.Size = new System.Drawing.Size(105, 55);
            this.prolonger1Button.TabIndex = 4;
            this.prolonger1Button.Text = "Prolonger l\'emprunt";
            this.prolonger1Button.UseVisualStyleBackColor = true;
            this.prolonger1Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // prolongerTousButton
            // 
            this.prolongerTousButton.Location = new System.Drawing.Point(219, 219);
            this.prolongerTousButton.Name = "prolongerTousButton";
            this.prolongerTousButton.Size = new System.Drawing.Size(105, 55);
            this.prolongerTousButton.TabIndex = 5;
            this.prolongerTousButton.Text = "Prolonger TOUS les emprunts";
            this.prolongerTousButton.UseVisualStyleBackColor = true;
            this.prolongerTousButton.Click += new System.EventHandler(this.prolongerTousButton_Click);
            // 
            // Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prolongerTousButton);
            this.Controls.Add(this.prolonger1Button);
            this.Controls.Add(this.listBox1);
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button prolonger1Button;
        private System.Windows.Forms.Button prolongerTousButton;
    }
}