
namespace PT2
{
    partial class RajoutVinyle
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
            this.comboBoxEditeur = new System.Windows.Forms.ComboBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.textBoxTitre = new System.Windows.Forms.TextBox();
            this.nUDAnneeParution = new System.Windows.Forms.NumericUpDown();
            this.nUDPrix = new System.Windows.Forms.NumericUpDown();
            this.textBoxAlle = new System.Windows.Forms.TextBox();
            this.nUDCasier = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxPochette = new System.Windows.Forms.PictureBox();
            this.boutonChangeImage = new System.Windows.Forms.Button();
            this.boutonAjouter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnneeParution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCasier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPochette)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditeur
            // 
            this.comboBoxEditeur.FormattingEnabled = true;
            this.comboBoxEditeur.Location = new System.Drawing.Point(255, 13);
            this.comboBoxEditeur.Name = "comboBoxEditeur";
            this.comboBoxEditeur.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEditeur.TabIndex = 0;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(255, 40);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGenre.TabIndex = 1;
            // 
            // textBoxTitre
            // 
            this.textBoxTitre.Location = new System.Drawing.Point(13, 13);
            this.textBoxTitre.Name = "textBoxTitre";
            this.textBoxTitre.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitre.TabIndex = 2;
            // 
            // nUDAnneeParution
            // 
            this.nUDAnneeParution.Location = new System.Drawing.Point(255, 67);
            this.nUDAnneeParution.Name = "nUDAnneeParution";
            this.nUDAnneeParution.Size = new System.Drawing.Size(100, 20);
            this.nUDAnneeParution.TabIndex = 3;
            // 
            // nUDPrix
            // 
            this.nUDPrix.Location = new System.Drawing.Point(13, 41);
            this.nUDPrix.Name = "nUDPrix";
            this.nUDPrix.Size = new System.Drawing.Size(100, 20);
            this.nUDPrix.TabIndex = 4;
            // 
            // textBoxAlle
            // 
            this.textBoxAlle.Location = new System.Drawing.Point(13, 67);
            this.textBoxAlle.Name = "textBoxAlle";
            this.textBoxAlle.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlle.TabIndex = 5;
            // 
            // nUDCasier
            // 
            this.nUDCasier.Location = new System.Drawing.Point(12, 93);
            this.nUDCasier.Name = "nUDCasier";
            this.nUDCasier.Size = new System.Drawing.Size(100, 20);
            this.nUDCasier.TabIndex = 6;
            // 
            // pictureBoxPochette
            // 
            this.pictureBoxPochette.Location = new System.Drawing.Point(13, 119);
            this.pictureBoxPochette.Name = "pictureBoxPochette";
            this.pictureBoxPochette.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxPochette.TabIndex = 7;
            this.pictureBoxPochette.TabStop = false;
            // 
            // boutonChangeImage
            // 
            this.boutonChangeImage.Location = new System.Drawing.Point(119, 146);
            this.boutonChangeImage.Name = "boutonChangeImage";
            this.boutonChangeImage.Size = new System.Drawing.Size(105, 23);
            this.boutonChangeImage.TabIndex = 8;
            this.boutonChangeImage.Text = "Changer Image";
            this.boutonChangeImage.UseVisualStyleBackColor = true;
            // 
            // boutonAjouter
            // 
            this.boutonAjouter.Location = new System.Drawing.Point(275, 272);
            this.boutonAjouter.Name = "boutonAjouter";
            this.boutonAjouter.Size = new System.Drawing.Size(100, 23);
            this.boutonAjouter.TabIndex = 9;
            this.boutonAjouter.Text = "Importer le Vinyle";
            this.boutonAjouter.UseVisualStyleBackColor = true;
            this.boutonAjouter.Click += new System.EventHandler(this.boutonAjouter_Click);
            // 
            // RajoutVinyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 307);
            this.Controls.Add(this.boutonAjouter);
            this.Controls.Add(this.boutonChangeImage);
            this.Controls.Add(this.pictureBoxPochette);
            this.Controls.Add(this.nUDCasier);
            this.Controls.Add(this.textBoxAlle);
            this.Controls.Add(this.nUDPrix);
            this.Controls.Add(this.nUDAnneeParution);
            this.Controls.Add(this.textBoxTitre);
            this.Controls.Add(this.comboBoxGenre);
            this.Controls.Add(this.comboBoxEditeur);
            this.Name = "RajoutVinyle";
            this.Text = "RajoutVinyle";
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnneeParution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCasier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPochette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEditeur;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.TextBox textBoxTitre;
        private System.Windows.Forms.NumericUpDown nUDAnneeParution;
        private System.Windows.Forms.NumericUpDown nUDPrix;
        private System.Windows.Forms.TextBox textBoxAlle;
        private System.Windows.Forms.NumericUpDown nUDCasier;
        private System.Windows.Forms.PictureBox pictureBoxPochette;
        private System.Windows.Forms.Button boutonChangeImage;
        private System.Windows.Forms.Button boutonAjouter;
    }
}