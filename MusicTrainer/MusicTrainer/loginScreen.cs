using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SQLite;

namespace MusicTrainer
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private Program.User getUserByUsername(string username)
        {
            try
            {
                return Program.DB.Table<Program.User>().Where(user => user.Username.Equals(this.loginUsernameEntry.Text)).First();
            }
            catch
            {
                return null;
            }
        }

        bool ValidateEntries()
        {
            bool missingUsername, missingPassword;
            missingUsername = missingPassword = false;

            if (loginUsernameEntry.Text == "") missingUsername = true;
            if (loginPasswordEntry.Text == "") missingPassword = true;

            if (missingUsername && missingPassword) loginErrorMessage.Text = "Please enter your username and password";
            if (missingUsername && !missingPassword) loginErrorMessage.Text = "Please enter your username";
            if (!missingUsername && missingPassword) loginErrorMessage.Text = "Please enter your password";

            if (missingUsername || missingPassword) return false;
            return true;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries()) return;
 
            string wrongLoginMessage = "Wrong username or password";

            Program.User user = getUserByUsername(loginUsernameEntry.Text);
            if (user == null)
            {
                loginErrorMessage.Text = wrongLoginMessage;
                return;
            }

            string hashedPassword = user.Hashed_pw;
            byte[] salt = user.Salt;
        
            var hashedPwEntered = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: loginPasswordEntry.Text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (hashedPassword != hashedPwEntered)
            {
                loginErrorMessage.Text = wrongLoginMessage;
                return;
            }
            //saves the userId of the user logged in, so other parts can update the user
            Program.userId = user.Id;

            this.Hide();
            Program.selectionScreen.Show();
        
        }

        private void SignUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.signUpScreen.Show();
        }
    }
}
