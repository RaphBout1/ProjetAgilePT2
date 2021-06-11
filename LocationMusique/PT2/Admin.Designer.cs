
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
            this.enRetardButton = new System.Windows.Forms.Button();
            this.Pluspopulairebutton = new System.Windows.Forms.Button();
            this.purgerModeButton = new System.Windows.Forms.Button();
            this.prolongesButton = new System.Windows.Forms.Button();
            this.moinsPopulaireButton = new System.Windows.Forms.Button();
            this.listeAbonnés = new System.Windows.Forms.Button();
            this.buttonChangerMdp = new System.Windows.Forms.Button();
            this.quitter = new System.Windows.Forms.Button();
            this.listBoxAllée = new System.Windows.Forms.ListBox();
            this.listBoxCasier = new System.Windows.Forms.ListBox();
            this.labelAllée = new System.Windows.Forms.Label();
            this.labelCasier = new System.Windows.Forms.Label();
            this.buttonCasier = new System.Windows.Forms.Button();
            this.buttonAllée = new System.Windows.Forms.Button();
            this.dataGridViewGlobale = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobale)).BeginInit();
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
            this.purgebutton.Location = new System.Drawing.Point(1436, 479);
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
            this.listBoxAbonnés.Location = new System.Drawing.Point(1244, 117);
            this.listBoxAbonnés.Name = "listBoxAbonnés";
            this.listBoxAbonnés.Size = new System.Drawing.Size(328, 147);
            this.listBoxAbonnés.TabIndex = 7;
            this.listBoxAbonnés.Visible = false;
            this.listBoxAbonnés.SelectedIndexChanged += new System.EventHandler(this.listBoxAbonnés_SelectedIndexChanged);
            // 
            // listBoxGlobale
            // 
            this.listBoxGlobale.FormattingEnabled = true;
            this.listBoxGlobale.Location = new System.Drawing.Point(738, 651);
            this.listBoxGlobale.Name = "listBoxGlobale";
            this.listBoxGlobale.Size = new System.Drawing.Size(505, 602);
            this.listBoxGlobale.TabIndex = 9;
            this.listBoxGlobale.SelectedIndexChanged += new System.EventHandler(this.listBoxGlobale_SelectedIndexChanged);
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
            this.enRetardButton.Location = new System.Drawing.Point(1322, 290);
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
            this.Pluspopulairebutton.Location = new System.Drawing.Point(101, 210);
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
            this.purgerModeButton.Location = new System.Drawing.Point(1306, 374);
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
            this.prolongesButton.Location = new System.Drawing.Point(32, 117);
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
            this.moinsPopulaireButton.Location = new System.Drawing.Point(158, 312);
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
            this.listeAbonnés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.listeAbonnés.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listeAbonnés.FlatAppearance.BorderSize = 0;
            this.listeAbonnés.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.listeAbonnés.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listeAbonnés.Location = new System.Drawing.Point(80, 714);
            this.listeAbonnés.Name = "listeAbonnés";
            this.listeAbonnés.Size = new System.Drawing.Size(149, 64);
            this.listeAbonnés.TabIndex = 16;
            this.listeAbonnés.Text = " ";
            this.listeAbonnés.UseVisualStyleBackColor = false;
            this.listeAbonnés.Click += new System.EventHandler(this.listeAbonnés_Click);
            // 
            // buttonChangerMdp
            // 
            this.buttonChangerMdp.BackColor = System.Drawing.Color.Transparent;
            this.buttonChangerMdp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonChangerMdp.BackgroundImage")));
            this.buttonChangerMdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChangerMdp.FlatAppearance.BorderSize = 0;
            this.buttonChangerMdp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonChangerMdp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangerMdp.Location = new System.Drawing.Point(1383, 541);
            this.buttonChangerMdp.Name = "buttonChangerMdp";
            this.buttonChangerMdp.Size = new System.Drawing.Size(189, 50);
            this.buttonChangerMdp.TabIndex = 17;
            this.buttonChangerMdp.UseVisualStyleBackColor = false;
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
            // listBoxAllée
            // 
            this.listBoxAllée.FormattingEnabled = true;
            this.listBoxAllée.Location = new System.Drawing.Point(555, 210);
            this.listBoxAllée.Name = "listBoxAllée";
            this.listBoxAllée.Size = new System.Drawing.Size(84, 173);
            this.listBoxAllée.TabIndex = 20;
            this.listBoxAllée.SelectedIndexChanged += new System.EventHandler(this.listBoxAllée_SelectedIndexChanged);
            // 
            // listBoxCasier
            // 
            this.listBoxCasier.FormattingEnabled = true;
            this.listBoxCasier.Location = new System.Drawing.Point(555, 520);
            this.listBoxCasier.Name = "listBoxCasier";
            this.listBoxCasier.Size = new System.Drawing.Size(84, 173);
            this.listBoxCasier.TabIndex = 21;
            this.listBoxCasier.SelectedIndexChanged += new System.EventHandler(this.listBoxCasier_SelectedIndexChanged);
            // 
            // labelAllée
            // 
            this.labelAllée.AutoSize = true;
            this.labelAllée.Location = new System.Drawing.Point(552, 194);
            this.labelAllée.Name = "labelAllée";
            this.labelAllée.Size = new System.Drawing.Size(36, 13);
            this.labelAllée.TabIndex = 22;
            this.labelAllée.Text = "Allée :";
            // 
            // labelCasier
            // 
            this.labelCasier.AutoSize = true;
            this.labelCasier.Location = new System.Drawing.Point(552, 504);
            this.labelCasier.Name = "labelCasier";
            this.labelCasier.Size = new System.Drawing.Size(65, 13);
            this.labelCasier.TabIndex = 23;
            this.labelCasier.Text = "Casier num :";
            // 
            // buttonCasier
            // 
            this.buttonCasier.Location = new System.Drawing.Point(564, 755);
            this.buttonCasier.Name = "buttonCasier";
            this.buttonCasier.Size = new System.Drawing.Size(75, 23);
            this.buttonCasier.TabIndex = 24;
            this.buttonCasier.Text = "Rechercher";
            this.buttonCasier.UseVisualStyleBackColor = true;
            this.buttonCasier.Click += new System.EventHandler(this.buttonCasier_Click);
            // 
            // buttonAllée
            // 
            this.buttonAllée.BackColor = System.Drawing.Color.Transparent;
            this.buttonAllée.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAllée.BackgroundImage")));
            this.buttonAllée.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAllée.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAllée.FlatAppearance.BorderSize = 0;
            this.buttonAllée.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonAllée.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllée.Location = new System.Drawing.Point(140, 427);
            this.buttonAllée.Name = "buttonAllée";
            this.buttonAllée.Size = new System.Drawing.Size(341, 126);
            this.buttonAllée.TabIndex = 25;
            this.buttonAllée.UseVisualStyleBackColor = false;
            this.buttonAllée.Click += new System.EventHandler(this.buttonAllée_Click);
            // 
            // dataGridViewGlobale
            // 
            this.dataGridViewGlobale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlobale.Location = new System.Drawing.Point(692, 143);
            this.dataGridViewGlobale.Name = "dataGridViewGlobale";
            this.dataGridViewGlobale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGlobale.Size = new System.Drawing.Size(546, 532);
            this.dataGridViewGlobale.TabIndex = 26;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.dataGridViewGlobale);
            this.Controls.Add(this.buttonAllée);
            this.Controls.Add(this.buttonCasier);
            this.Controls.Add(this.labelCasier);
            this.Controls.Add(this.labelAllée);
            this.Controls.Add(this.listBoxCasier);
            this.Controls.Add(this.listBoxAllée);
            this.Controls.Add(this.quitter);
            this.Controls.Add(this.buttonChangerMdp);
            this.Controls.Add(this.listeAbonnés);
            this.Controls.Add(this.moinsPopulaireButton);
            this.Controls.Add(this.prolongesButton);
            this.Controls.Add(this.purgerModeButton);
            this.Controls.Add(this.Pluspopulairebutton);
            this.Controls.Add(this.enRetardButton);
            this.Controls.Add(this.listBoxGlobale);
            this.Controls.Add(this.listBoxAbonnés);
            this.Controls.Add(this.purgebutton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button purgebutton;
        private System.Windows.Forms.ListBox listBoxAbonnés;
        private System.Windows.Forms.ListBox listBoxGlobale;
        private System.Windows.Forms.Button enRetardButton;
        private System.Windows.Forms.Button Pluspopulairebutton;
        private System.Windows.Forms.Button purgerModeButton;
        private System.Windows.Forms.Button prolongesButton;
        private System.Windows.Forms.Button moinsPopulaireButton;
        private System.Windows.Forms.Button listeAbonnés;
        private System.Windows.Forms.Button buttonChangerMdp;
        private System.Windows.Forms.Button quitter;
        private System.Windows.Forms.ListBox listBoxAllée;
        private System.Windows.Forms.ListBox listBoxCasier;
        private System.Windows.Forms.Label labelAllée;
        private System.Windows.Forms.Label labelCasier;
        private System.Windows.Forms.Button buttonCasier;
        private System.Windows.Forms.Button buttonAllée;
        private System.Windows.Forms.DataGridView dataGridViewGlobale;
    }
}