namespace MusicTrainer
{
    partial class SignUpScreen
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
            this.signUpUsernameEntry = new System.Windows.Forms.TextBox();
            this.signUpPasswordEntry = new System.Windows.Forms.MaskedTextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.signUpEmailEntry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.signUpErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signUpUsernameEntry
            // 
            this.signUpUsernameEntry.Location = new System.Drawing.Point(513, 391);
            this.signUpUsernameEntry.MaxLength = 254;
            this.signUpUsernameEntry.Name = "signUpUsernameEntry";
            this.signUpUsernameEntry.Size = new System.Drawing.Size(160, 20);
            this.signUpUsernameEntry.TabIndex = 1;
            // 
            // signUpPasswordEntry
            // 
            this.signUpPasswordEntry.Location = new System.Drawing.Point(513, 430);
            this.signUpPasswordEntry.Name = "signUpPasswordEntry";
            this.signUpPasswordEntry.PasswordChar = '*';
            this.signUpPasswordEntry.ResetOnPrompt = false;
            this.signUpPasswordEntry.Size = new System.Drawing.Size(160, 20);
            this.signUpPasswordEntry.TabIndex = 2;
            this.signUpPasswordEntry.UseSystemPasswordChar = true;
            // 
            // signUpButton
            // 
            this.signUpButton.Font = new System.Drawing.Font("Tahoma", 11F);
            this.signUpButton.Location = new System.Drawing.Point(550, 456);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(82, 27);
            this.signUpButton.TabIndex = 3;
            this.signUpButton.Text = "Sign up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label3.Location = new System.Drawing.Point(457, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 41);
            this.label3.TabIndex = 10;
            this.label3.Text = "Create Account";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(433, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(427, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // signUpEmailEntry
            // 
            this.signUpEmailEntry.Location = new System.Drawing.Point(513, 353);
            this.signUpEmailEntry.MaxLength = 254;
            this.signUpEmailEntry.Name = "signUpEmailEntry";
            this.signUpEmailEntry.Size = new System.Drawing.Size(160, 20);
            this.signUpEmailEntry.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(461, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Email:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // signUpErrorMessage
            // 
            this.signUpErrorMessage.AutoSize = true;
            this.signUpErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.signUpErrorMessage.Location = new System.Drawing.Point(507, 319);
            this.signUpErrorMessage.Name = "signUpErrorMessage";
            this.signUpErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.signUpErrorMessage.TabIndex = 15;
            // 
            // SignUpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.signUpErrorMessage);
            this.Controls.Add(this.signUpEmailEntry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signUpUsernameEntry);
            this.Controls.Add(this.signUpPasswordEntry);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SignUpScreen";
            this.Text = "SignUpScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox signUpUsernameEntry;
        private System.Windows.Forms.MaskedTextBox signUpPasswordEntry;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox signUpEmailEntry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label signUpErrorMessage;
    }
}