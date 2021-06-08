
namespace PT2
{
    partial class UtilisateurUSEmprunt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDNumeroAlbumAEmprunter = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTitreAlbumAEmprunter = new System.Windows.Forms.ComboBox();
            this.boutonEmprunterAlbumPrecis = new System.Windows.Forms.Button();
            this.monthCalendarClassique = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroAlbumAEmprunter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titre :";
            // 
            // nUDNumeroAlbumAEmprunter
            // 
            this.nUDNumeroAlbumAEmprunter.Location = new System.Drawing.Point(52, 10);
            this.nUDNumeroAlbumAEmprunter.Name = "nUDNumeroAlbumAEmprunter";
            this.nUDNumeroAlbumAEmprunter.Size = new System.Drawing.Size(52, 20);
            this.nUDNumeroAlbumAEmprunter.TabIndex = 2;
            this.nUDNumeroAlbumAEmprunter.ValueChanged += new System.EventHandler(this.nUDNumeroAlbumAEmprunter_ValueChanged);
            // 
            // comboBoxTitreAlbumAEmprunter
            // 
            this.comboBoxTitreAlbumAEmprunter.FormattingEnabled = true;
            this.comboBoxTitreAlbumAEmprunter.Location = new System.Drawing.Point(52, 36);
            this.comboBoxTitreAlbumAEmprunter.Name = "comboBoxTitreAlbumAEmprunter";
            this.comboBoxTitreAlbumAEmprunter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTitreAlbumAEmprunter.TabIndex = 3;
            this.comboBoxTitreAlbumAEmprunter.SelectedIndexChanged += new System.EventHandler(this.comboBoxTitreAlbumAEmprunter_SelectedIndexChanged);
            // 
            // boutonEmprunterAlbumPrecis
            // 
            this.boutonEmprunterAlbumPrecis.Location = new System.Drawing.Point(13, 71);
            this.boutonEmprunterAlbumPrecis.Name = "boutonEmprunterAlbumPrecis";
            this.boutonEmprunterAlbumPrecis.Size = new System.Drawing.Size(75, 23);
            this.boutonEmprunterAlbumPrecis.TabIndex = 4;
            this.boutonEmprunterAlbumPrecis.Text = "Emprunter";
            this.boutonEmprunterAlbumPrecis.UseVisualStyleBackColor = true;
            this.boutonEmprunterAlbumPrecis.Click += new System.EventHandler(this.boutonEmprunterAlbumPrecis_Click);
            // 
            // monthCalendarClassique
            // 
            this.monthCalendarClassique.Location = new System.Drawing.Point(18, 106);
            this.monthCalendarClassique.Name = "monthCalendarClassique";
            this.monthCalendarClassique.TabIndex = 5;
            // 
            // UtilisateurUSEmprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendarClassique);
            this.Controls.Add(this.boutonEmprunterAlbumPrecis);
            this.Controls.Add(this.comboBoxTitreAlbumAEmprunter);
            this.Controls.Add(this.nUDNumeroAlbumAEmprunter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UtilisateurUSEmprunt";
            this.Text = "UtilisateurUSEmprunt";
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroAlbumAEmprunter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDNumeroAlbumAEmprunter;
        private System.Windows.Forms.ComboBox comboBoxTitreAlbumAEmprunter;
        private System.Windows.Forms.Button boutonEmprunterAlbumPrecis;
        private System.Windows.Forms.MonthCalendar monthCalendarClassique;
    }
}