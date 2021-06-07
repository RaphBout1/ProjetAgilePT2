
namespace PT2
{
    partial class Admin
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
            this.listeRetard = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listeAbonnésInactifs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listeRetard
            // 
            this.listeRetard.FormattingEnabled = true;
            this.listeRetard.Location = new System.Drawing.Point(32, 32);
            this.listeRetard.Name = "listeRetard";
            this.listeRetard.Size = new System.Drawing.Size(206, 95);
            this.listeRetard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "En retard de +10 jours";
            // 
            // listeAbonnésInactifs
            // 
            this.listeAbonnésInactifs.FormattingEnabled = true;
            this.listeAbonnésInactifs.Location = new System.Drawing.Point(32, 265);
            this.listeAbonnésInactifs.Name = "listeAbonnésInactifs";
            this.listeAbonnésInactifs.Size = new System.Drawing.Size(273, 160);
            this.listeAbonnésInactifs.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Abonnés purgeables";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listeAbonnésInactifs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listeRetard);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listeRetard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listeAbonnésInactifs;
        private System.Windows.Forms.Label label2;
    }
}