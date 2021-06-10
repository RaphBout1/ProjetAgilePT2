
namespace PT2
{
    partial class Inscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inscription));
            this.loginText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.nomText = new System.Windows.Forms.TextBox();
            this.prenomText = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.paysComboBox = new System.Windows.Forms.ComboBox();
            this.suiteButton = new System.Windows.Forms.Button();
            this.nomPrenomPaysImage = new System.Windows.Forms.PictureBox();
            this.loginmdpImage = new System.Windows.Forms.PictureBox();
            this.retour = new System.Windows.Forms.Button();
            this.confirmationMdpBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nomPrenomPaysImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginmdpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // loginText
            // 
            this.loginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginText.Location = new System.Drawing.Point(1093, 96);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(408, 35);
            this.loginText.TabIndex = 0;
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(1093, 240);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(408, 35);
            this.passwordText.TabIndex = 3;
            this.passwordText.UseSystemPasswordChar = true;
            // 
            // nomText
            // 
            this.nomText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomText.Location = new System.Drawing.Point(1029, 75);
            this.nomText.Name = "nomText";
            this.nomText.Size = new System.Drawing.Size(472, 35);
            this.nomText.TabIndex = 4;
            // 
            // prenomText
            // 
            this.prenomText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenomText.Location = new System.Drawing.Point(1029, 161);
            this.prenomText.Name = "prenomText";
            this.prenomText.Size = new System.Drawing.Size(472, 35);
            this.prenomText.TabIndex = 5;
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.Transparent;
            this.submit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("submit.BackgroundImage")));
            this.submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.submit.FlatAppearance.BorderSize = 0;
            this.submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit.Location = new System.Drawing.Point(1029, 754);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(414, 80);
            this.submit.TabIndex = 10;
            this.submit.Text = " ";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(143, 754);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(412, 76);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = " ";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // paysComboBox
            // 
            this.paysComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paysComboBox.FormattingEnabled = true;
            this.paysComboBox.Location = new System.Drawing.Point(1029, 252);
            this.paysComboBox.Name = "paysComboBox";
            this.paysComboBox.Size = new System.Drawing.Size(472, 37);
            this.paysComboBox.TabIndex = 12;
            // 
            // suiteButton
            // 
            this.suiteButton.BackColor = System.Drawing.Color.Transparent;
            this.suiteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("suiteButton.BackgroundImage")));
            this.suiteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.suiteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.suiteButton.FlatAppearance.BorderSize = 0;
            this.suiteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.suiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suiteButton.Location = new System.Drawing.Point(1051, 754);
            this.suiteButton.Name = "suiteButton";
            this.suiteButton.Size = new System.Drawing.Size(374, 80);
            this.suiteButton.TabIndex = 13;
            this.suiteButton.Text = " ";
            this.suiteButton.UseVisualStyleBackColor = false;
            this.suiteButton.Click += new System.EventHandler(this.suiteButton_Click);
            // 
            // nomPrenomPaysImage
            // 
            this.nomPrenomPaysImage.BackColor = System.Drawing.Color.Transparent;
            this.nomPrenomPaysImage.Image = ((System.Drawing.Image)(resources.GetObject("nomPrenomPaysImage.Image")));
            this.nomPrenomPaysImage.Location = new System.Drawing.Point(838, 35);
            this.nomPrenomPaysImage.Name = "nomPrenomPaysImage";
            this.nomPrenomPaysImage.Size = new System.Drawing.Size(214, 284);
            this.nomPrenomPaysImage.TabIndex = 14;
            this.nomPrenomPaysImage.TabStop = false;
            // 
            // loginmdpImage
            // 
            this.loginmdpImage.BackColor = System.Drawing.Color.Transparent;
            this.loginmdpImage.Image = ((System.Drawing.Image)(resources.GetObject("loginmdpImage.Image")));
            this.loginmdpImage.Location = new System.Drawing.Point(828, -3);
            this.loginmdpImage.Name = "loginmdpImage";
            this.loginmdpImage.Size = new System.Drawing.Size(280, 356);
            this.loginmdpImage.TabIndex = 15;
            this.loginmdpImage.TabStop = false;
            // 
            // retour
            // 
            this.retour.BackColor = System.Drawing.Color.Transparent;
            this.retour.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("retour.BackgroundImage")));
            this.retour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.retour.FlatAppearance.BorderSize = 0;
            this.retour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.retour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retour.Location = new System.Drawing.Point(143, 753);
            this.retour.Name = "retour";
            this.retour.Size = new System.Drawing.Size(411, 83);
            this.retour.TabIndex = 16;
            this.retour.UseVisualStyleBackColor = false;
            this.retour.Click += new System.EventHandler(this.retour_Click);
            // 
            // confirmationMdpBox
            // 
            this.confirmationMdpBox.Location = new System.Drawing.Point(1150, 371);
            this.confirmationMdpBox.Name = "confirmationMdpBox";
            this.confirmationMdpBox.Size = new System.Drawing.Size(100, 20);
            this.confirmationMdpBox.TabIndex = 17;
            // 
            // Inscription
            // 
            this.AcceptButton = this.submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.confirmationMdpBox);
            this.Controls.Add(this.retour);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.loginmdpImage);
            this.Controls.Add(this.suiteButton);
            this.Controls.Add(this.paysComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.prenomText);
            this.Controls.Add(this.nomText);
            this.Controls.Add(this.nomPrenomPaysImage);
            this.DoubleBuffered = true;
            this.Name = "Inscription";
            this.Text = "Inscription";
            ((System.ComponentModel.ISupportInitialize)(this.nomPrenomPaysImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginmdpImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox nomText;
        private System.Windows.Forms.TextBox prenomText;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox paysComboBox;
        private System.Windows.Forms.Button suiteButton;
        private System.Windows.Forms.PictureBox nomPrenomPaysImage;
        private System.Windows.Forms.PictureBox loginmdpImage;
        private System.Windows.Forms.Button retour;
        private System.Windows.Forms.TextBox confirmationMdpBox;
    }
}