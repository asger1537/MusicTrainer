namespace MusicTrainer
{
    partial class LoginScreen
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
            this.label3 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginPasswordEntry = new System.Windows.Forms.MaskedTextBox();
            this.loginUsernameEntry = new System.Windows.Forms.TextBox();
            this.signUpLink = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.loginErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(423, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(429, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 47F);
            this.label3.Location = new System.Drawing.Point(379, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 76);
            this.label3.TabIndex = 2;
            this.label3.Text = "Music Trainer";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Tahoma", 11F);
            this.loginButton.Location = new System.Drawing.Point(543, 389);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(82, 27);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // loginPasswordEntry
            // 
            this.loginPasswordEntry.Location = new System.Drawing.Point(509, 354);
            this.loginPasswordEntry.Name = "loginPasswordEntry";
            this.loginPasswordEntry.PasswordChar = '*';
            this.loginPasswordEntry.Size = new System.Drawing.Size(160, 20);
            this.loginPasswordEntry.TabIndex = 1;
            // 
            // loginUsernameEntry
            // 
            this.loginUsernameEntry.Location = new System.Drawing.Point(509, 314);
            this.loginUsernameEntry.Name = "loginUsernameEntry";
            this.loginUsernameEntry.Size = new System.Drawing.Size(160, 20);
            this.loginUsernameEntry.TabIndex = 0;
            // 
            // signUpLink
            // 
            this.signUpLink.AutoSize = true;
            this.signUpLink.Font = new System.Drawing.Font("Tahoma", 11F);
            this.signUpLink.Location = new System.Drawing.Point(560, 444);
            this.signUpLink.Name = "signUpLink";
            this.signUpLink.Size = new System.Drawing.Size(55, 18);
            this.signUpLink.TabIndex = 6;
            this.signUpLink.TabStop = true;
            this.signUpLink.Text = "Sign up";
            this.signUpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignUpLink_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(522, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Don\'t have an account?";
            // 
            // loginErrorMessage
            // 
            this.loginErrorMessage.AutoSize = true;
            this.loginErrorMessage.Location = new System.Drawing.Point(503, 283);
            this.loginErrorMessage.Name = "loginErrorMessage";
            this.loginErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.loginErrorMessage.TabIndex = 8;
            // 
            // loginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.loginErrorMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signUpLink);
            this.Controls.Add(this.loginUsernameEntry);
            this.Controls.Add(this.loginPasswordEntry);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "loginScreen";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.MaskedTextBox loginPasswordEntry;
        private System.Windows.Forms.TextBox loginUsernameEntry;
        private System.Windows.Forms.LinkLabel signUpLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label loginErrorMessage;
    }
}

