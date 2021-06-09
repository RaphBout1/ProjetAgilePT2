
namespace PT2
{
    partial class US14Rendre
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
            this.listBoxEmpruntEnCours = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rendreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxEmpruntEnCours
            // 
            this.listBoxEmpruntEnCours.FormattingEnabled = true;
            this.listBoxEmpruntEnCours.Location = new System.Drawing.Point(158, 47);
            this.listBoxEmpruntEnCours.Name = "listBoxEmpruntEnCours";
            this.listBoxEmpruntEnCours.Size = new System.Drawing.Size(467, 290);
            this.listBoxEmpruntEnCours.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liste des emprunts en cours";
            // 
            // rendreButton
            // 
            this.rendreButton.Location = new System.Drawing.Point(302, 359);
            this.rendreButton.Name = "rendreButton";
            this.rendreButton.Size = new System.Drawing.Size(165, 79);
            this.rendreButton.TabIndex = 2;
            this.rendreButton.Text = "Rendre";
            this.rendreButton.UseVisualStyleBackColor = true;
            this.rendreButton.Click += new System.EventHandler(this.rendreButton_Click);
            // 
            // US14Rendre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rendreButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxEmpruntEnCours);
            this.Name = "US14Rendre";
            this.Text = "US14Rendre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEmpruntEnCours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rendreButton;
    }
}