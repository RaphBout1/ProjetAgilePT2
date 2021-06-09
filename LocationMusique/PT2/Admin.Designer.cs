
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(32, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 95);
            this.listBox1.TabIndex = 0;
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
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(319, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(179, 95);
            this.listBox2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(316, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Emprunts prolongés";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(572, 32);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(171, 95);
            this.listBox3.TabIndex = 4;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Abonnés à purger";
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
            this.purgebutton.Size = new System.Drawing.Size(75, 23);
            this.purgebutton.TabIndex = 6;
            this.purgebutton.Text = "Purger";
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
            // 
            // prolongesButton
            // 
            this.prolongesButton.Location = new System.Drawing.Point(58, 203);
            this.prolongesButton.Name = "prolongesButton";
            this.prolongesButton.Size = new System.Drawing.Size(75, 23);
            this.prolongesButton.TabIndex = 14;
            this.prolongesButton.Text = "Prolonges";
            this.prolongesButton.UseVisualStyleBackColor = true;
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
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
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
    }
}