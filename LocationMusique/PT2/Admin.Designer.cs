﻿
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
            this.label2 = new System.Windows.Forms.Label();
            this.purgebutton = new System.Windows.Forms.Button();
            this.listBoxAbonnés = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxGlobale = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.enRetardButton = new System.Windows.Forms.Button();
            this.Pluspopulairebutton = new System.Windows.Forms.Button();
            this.purgerModeButton = new System.Windows.Forms.Button();
            this.prolongesButton = new System.Windows.Forms.Button();
            this.moinsPopulaireButton = new System.Windows.Forms.Button();
            this.listeAbonnés = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // purgebutton
            // 
            this.purgebutton.Enabled = false;
            this.purgebutton.Location = new System.Drawing.Point(572, 158);
            this.purgebutton.Name = "purgebutton";
            this.purgebutton.Size = new System.Drawing.Size(126, 23);
            this.purgebutton.TabIndex = 6;
            this.purgebutton.Text = "Purger l\'abonné";
            this.purgebutton.UseVisualStyleBackColor = true;
            this.purgebutton.Click += new System.EventHandler(this.purgebutton_Click);
            // 
            // listBoxAbonnés
            // 
            this.listBoxAbonnés.FormattingEnabled = true;
            this.listBoxAbonnés.Location = new System.Drawing.Point(35, 294);
            this.listBoxAbonnés.Name = "listBoxAbonnés";
            this.listBoxAbonnés.Size = new System.Drawing.Size(223, 147);
            this.listBoxAbonnés.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Liste des abonnés";
            // 
            // listBoxGlobale
            // 
            this.listBoxGlobale.FormattingEnabled = true;
            this.listBoxGlobale.Location = new System.Drawing.Point(462, 275);
            this.listBoxGlobale.Name = "listBoxGlobale";
            this.listBoxGlobale.Size = new System.Drawing.Size(267, 160);
            this.listBoxGlobale.TabIndex = 9;
            this.listBoxGlobale.SelectedIndexChanged += new System.EventHandler(this.listBoxGlobale_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "listBoxglobale";
            // 
            // enRetardButton
            // 
            this.enRetardButton.Location = new System.Drawing.Point(58, 158);
            this.enRetardButton.Name = "enRetardButton";
            this.enRetardButton.Size = new System.Drawing.Size(75, 23);
            this.enRetardButton.TabIndex = 11;
            this.enRetardButton.Text = "En Retard";
            this.enRetardButton.UseVisualStyleBackColor = true;
            this.enRetardButton.Click += new System.EventHandler(this.enRetardButton_Click);
            // 
            // Pluspopulairebutton
            // 
            this.Pluspopulairebutton.Location = new System.Drawing.Point(166, 203);
            this.Pluspopulairebutton.Name = "Pluspopulairebutton";
            this.Pluspopulairebutton.Size = new System.Drawing.Size(127, 23);
            this.Pluspopulairebutton.TabIndex = 12;
            this.Pluspopulairebutton.Text = "Les plus populaires";
            this.Pluspopulairebutton.UseVisualStyleBackColor = true;
            this.Pluspopulairebutton.Click += new System.EventHandler(this.Pluspopulairebutton_Click);
            // 
            // purgerModeButton
            // 
            this.purgerModeButton.Location = new System.Drawing.Point(166, 158);
            this.purgerModeButton.Name = "purgerModeButton";
            this.purgerModeButton.Size = new System.Drawing.Size(75, 23);
            this.purgerModeButton.TabIndex = 13;
            this.purgerModeButton.Text = "Purger";
            this.purgerModeButton.UseVisualStyleBackColor = true;
            this.purgerModeButton.Click += new System.EventHandler(this.purgerModeButton_Click);
            // 
            // prolongesButton
            // 
            this.prolongesButton.Location = new System.Drawing.Point(58, 203);
            this.prolongesButton.Name = "prolongesButton";
            this.prolongesButton.Size = new System.Drawing.Size(75, 23);
            this.prolongesButton.TabIndex = 14;
            this.prolongesButton.Text = "Prolonges";
            this.prolongesButton.UseVisualStyleBackColor = true;
            this.prolongesButton.Click += new System.EventHandler(this.prolongesButton_Click);
            // 
            // moinsPopulaireButton
            // 
            this.moinsPopulaireButton.Location = new System.Drawing.Point(319, 203);
            this.moinsPopulaireButton.Name = "moinsPopulaireButton";
            this.moinsPopulaireButton.Size = new System.Drawing.Size(127, 23);
            this.moinsPopulaireButton.TabIndex = 15;
            this.moinsPopulaireButton.Text = "Les moins populaires";
            this.moinsPopulaireButton.UseVisualStyleBackColor = true;
            this.moinsPopulaireButton.Click += new System.EventHandler(this.moinsPopulaireButton_Click);
            // 
            // listeAbonnés
            // 
            this.listeAbonnés.Location = new System.Drawing.Point(309, 158);
            this.listeAbonnés.Name = "listeAbonnés";
            this.listeAbonnés.Size = new System.Drawing.Size(127, 23);
            this.listeAbonnés.TabIndex = 16;
            this.listeAbonnés.Text = "Liste des abonnés";
            this.listeAbonnés.UseVisualStyleBackColor = true;
            this.listeAbonnés.Click += new System.EventHandler(this.listeAbonnés_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listeAbonnés);
            this.Controls.Add(this.moinsPopulaireButton);
            this.Controls.Add(this.prolongesButton);
            this.Controls.Add(this.purgerModeButton);
            this.Controls.Add(this.Pluspopulairebutton);
            this.Controls.Add(this.enRetardButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxGlobale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxAbonnés);
            this.Controls.Add(this.purgebutton);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button purgebutton;
        private System.Windows.Forms.ListBox listBoxAbonnés;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxGlobale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button enRetardButton;
        private System.Windows.Forms.Button Pluspopulairebutton;
        private System.Windows.Forms.Button purgerModeButton;
        private System.Windows.Forms.Button prolongesButton;
        private System.Windows.Forms.Button moinsPopulaireButton;
        private System.Windows.Forms.Button listeAbonnés;
    }
}