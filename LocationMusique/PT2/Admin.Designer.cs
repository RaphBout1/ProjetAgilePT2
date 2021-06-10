
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.label2 = new System.Windows.Forms.Label();
            this.purgebutton = new System.Windows.Forms.Button();
            this.listBoxAbonnés = new System.Windows.Forms.ListBox();
            this.listBoxGlobale = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.enRetardButton = new System.Windows.Forms.Button();
            this.Pluspopulairebutton = new System.Windows.Forms.Button();
            this.purgerModeButton = new System.Windows.Forms.Button();
            this.prolongesButton = new System.Windows.Forms.Button();
            this.moinsPopulaireButton = new System.Windows.Forms.Button();
            this.listeAbonnés = new System.Windows.Forms.Button();
            this.buttonChangerMdp = new System.Windows.Forms.Button();
            this.quitter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            this.listBoxAbonnés.Location = new System.Drawing.Point(1099, 260);
            this.listBoxAbonnés.Name = "listBoxAbonnés";
            this.listBoxAbonnés.Size = new System.Drawing.Size(328, 147);
            this.listBoxAbonnés.TabIndex = 7;
            this.listBoxAbonnés.Visible = false;
            this.listBoxAbonnés.SelectedIndexChanged += new System.EventHandler(this.listBoxAbonnés_SelectedIndexChanged);
            // 
            // listBoxGlobale
            // 
            this.listBoxGlobale.FormattingEnabled = true;
            this.listBoxGlobale.Location = new System.Drawing.Point(586, 290);
            this.listBoxGlobale.Name = "listBoxGlobale";
            this.listBoxGlobale.Size = new System.Drawing.Size(316, 277);
            this.listBoxGlobale.TabIndex = 9;
            this.listBoxGlobale.SelectedIndexChanged += new System.EventHandler(this.listBoxGlobale_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "listBoxglobale";
            // 
            // enRetardButton
            // 
            this.enRetardButton.BackColor = System.Drawing.Color.Transparent;
            this.enRetardButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enRetardButton.BackgroundImage")));
            this.enRetardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enRetardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enRetardButton.FlatAppearance.BorderSize = 0;
            this.enRetardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.enRetardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enRetardButton.Location = new System.Drawing.Point(-16, 759);
            this.enRetardButton.Name = "enRetardButton";
            this.enRetardButton.Size = new System.Drawing.Size(309, 78);
            this.enRetardButton.TabIndex = 11;
            this.enRetardButton.Text = " ";
            this.enRetardButton.UseVisualStyleBackColor = false;
            this.enRetardButton.Click += new System.EventHandler(this.enRetardButton_Click);
            // 
            // Pluspopulairebutton
            // 
            this.Pluspopulairebutton.BackColor = System.Drawing.Color.Transparent;
            this.Pluspopulairebutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pluspopulairebutton.BackgroundImage")));
            this.Pluspopulairebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pluspopulairebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pluspopulairebutton.FlatAppearance.BorderSize = 0;
            this.Pluspopulairebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.Pluspopulairebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pluspopulairebutton.Location = new System.Drawing.Point(111, 227);
            this.Pluspopulairebutton.Name = "Pluspopulairebutton";
            this.Pluspopulairebutton.Size = new System.Drawing.Size(359, 80);
            this.Pluspopulairebutton.TabIndex = 12;
            this.Pluspopulairebutton.Text = " ";
            this.Pluspopulairebutton.UseVisualStyleBackColor = false;
            this.Pluspopulairebutton.Click += new System.EventHandler(this.Pluspopulairebutton_Click);
            // 
            // purgerModeButton
            // 
            this.purgerModeButton.BackColor = System.Drawing.Color.Transparent;
            this.purgerModeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("purgerModeButton.BackgroundImage")));
            this.purgerModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.purgerModeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.purgerModeButton.FlatAppearance.BorderSize = 0;
            this.purgerModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.purgerModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purgerModeButton.Location = new System.Drawing.Point(12, 663);
            this.purgerModeButton.Name = "purgerModeButton";
            this.purgerModeButton.Size = new System.Drawing.Size(325, 78);
            this.purgerModeButton.TabIndex = 13;
            this.purgerModeButton.Text = " ";
            this.purgerModeButton.UseVisualStyleBackColor = false;
            this.purgerModeButton.Click += new System.EventHandler(this.purgerModeButton_Click);
            // 
            // prolongesButton
            // 
            this.prolongesButton.BackColor = System.Drawing.Color.Transparent;
            this.prolongesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prolongesButton.BackgroundImage")));
            this.prolongesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prolongesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prolongesButton.FlatAppearance.BorderSize = 0;
            this.prolongesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.prolongesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prolongesButton.Location = new System.Drawing.Point(42, 123);
            this.prolongesButton.Name = "prolongesButton";
            this.prolongesButton.Size = new System.Drawing.Size(330, 64);
            this.prolongesButton.TabIndex = 14;
            this.prolongesButton.Text = " ";
            this.prolongesButton.UseVisualStyleBackColor = false;
            this.prolongesButton.Click += new System.EventHandler(this.prolongesButton_Click);
            // 
            // moinsPopulaireButton
            // 
            this.moinsPopulaireButton.BackColor = System.Drawing.Color.Transparent;
            this.moinsPopulaireButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moinsPopulaireButton.BackgroundImage")));
            this.moinsPopulaireButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moinsPopulaireButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moinsPopulaireButton.FlatAppearance.BorderSize = 0;
            this.moinsPopulaireButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.moinsPopulaireButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moinsPopulaireButton.Location = new System.Drawing.Point(164, 349);
            this.moinsPopulaireButton.Name = "moinsPopulaireButton";
            this.moinsPopulaireButton.Size = new System.Drawing.Size(345, 81);
            this.moinsPopulaireButton.TabIndex = 15;
            this.moinsPopulaireButton.Text = " ";
            this.moinsPopulaireButton.UseVisualStyleBackColor = false;
            this.moinsPopulaireButton.Click += new System.EventHandler(this.moinsPopulaireButton_Click);
            // 
            // listeAbonnés
            // 
            this.listeAbonnés.BackColor = System.Drawing.Color.Transparent;
            this.listeAbonnés.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listeAbonnés.BackgroundImage")));
            this.listeAbonnés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.listeAbonnés.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listeAbonnés.FlatAppearance.BorderSize = 0;
            this.listeAbonnés.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.listeAbonnés.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listeAbonnés.Location = new System.Drawing.Point(138, 576);
            this.listeAbonnés.Name = "listeAbonnés";
            this.listeAbonnés.Size = new System.Drawing.Size(342, 81);
            this.listeAbonnés.TabIndex = 16;
            this.listeAbonnés.Text = " ";
            this.listeAbonnés.UseVisualStyleBackColor = false;
            this.listeAbonnés.Click += new System.EventHandler(this.listeAbonnés_Click);
            // 
            // buttonChangerMdp
            // 
            this.buttonChangerMdp.Location = new System.Drawing.Point(1099, 469);
            this.buttonChangerMdp.Name = "buttonChangerMdp";
            this.buttonChangerMdp.Size = new System.Drawing.Size(98, 23);
            this.buttonChangerMdp.TabIndex = 17;
            this.buttonChangerMdp.Text = "changer mdp";
            this.buttonChangerMdp.UseVisualStyleBackColor = true;
            this.buttonChangerMdp.Click += new System.EventHandler(this.buttonChangerMdp_Click);
            // 
            // quitter
            // 
            this.quitter.BackColor = System.Drawing.Color.Transparent;
            this.quitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitter.BackgroundImage")));
            this.quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitter.FlatAppearance.BorderSize = 0;
            this.quitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitter.Location = new System.Drawing.Point(1280, 802);
            this.quitter.Name = "quitter";
            this.quitter.Size = new System.Drawing.Size(292, 56);
            this.quitter.TabIndex = 18;
            this.quitter.Text = " ";
            this.quitter.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1119, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "label1";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quitter);
            this.Controls.Add(this.buttonChangerMdp);
            this.Controls.Add(this.listeAbonnés);
            this.Controls.Add(this.moinsPopulaireButton);
            this.Controls.Add(this.prolongesButton);
            this.Controls.Add(this.purgerModeButton);
            this.Controls.Add(this.Pluspopulairebutton);
            this.Controls.Add(this.enRetardButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxGlobale);
            this.Controls.Add(this.listBoxAbonnés);
            this.Controls.Add(this.purgebutton);
            this.DoubleBuffered = true;
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button purgebutton;
        private System.Windows.Forms.ListBox listBoxAbonnés;
        private System.Windows.Forms.ListBox listBoxGlobale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button enRetardButton;
        private System.Windows.Forms.Button Pluspopulairebutton;
        private System.Windows.Forms.Button purgerModeButton;
        private System.Windows.Forms.Button prolongesButton;
        private System.Windows.Forms.Button moinsPopulaireButton;
        private System.Windows.Forms.Button listeAbonnés;
        private System.Windows.Forms.Button buttonChangerMdp;
        private System.Windows.Forms.Button quitter;
        private System.Windows.Forms.Label label4;
    }
}