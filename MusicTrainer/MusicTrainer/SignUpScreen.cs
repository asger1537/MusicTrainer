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

namespace MusicTrainer
{
    public partial class SignUpScreen : Form
    {
        public SignUpScreen()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private Program.User getUserByUsername(string username)
        {
            try
            {
                return Program.db.Table<Program.User>().Where(user => user.Username.Equals(signUpUsernameEntry.Text)).First();
            }
            catch
            {
                return null;
            }
        }

        private Program.User getUserByEmail(string username)
        {
            try
            {
                return Program.db.Table<Program.User>().Where(user => user.Email.Equals(signUpEmailEntry.Text)).First();
            }
            catch
            {
                return null;
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            bool missingUsername, missingPassword;
            missingUsername = missingPassword = false;

            //handling no entered username/password
            if (signUpUsernameEntry.Text == "") missingUsername = true;
            if (signUpPasswordEntry.Text == "") missingPassword = true;

            if (missingUsername && missingPassword) signUpErrorMessage.Text = "Please enter your username and password";
            if (missingUsername && !missingPassword) signUpErrorMessage.Text = "Please enter your username";
            if (!missingUsername && missingPassword) signUpErrorMessage.Text = "Please enter your password";
            if (missingUsername || missingPassword) return;

            int minPasswordLength = 8;
            if (signUpPasswordEntry.Text.Length < minPasswordLength)
            {
                signUpErrorMessage.Text = String.Format("Your password must be at least {0} characters long", minPasswordLength);
                return;
            }

            //handling already existing username
            Program.User user = getUserByUsername(signUpUsernameEntry.Text);
            if (user != null)
            {
                signUpErrorMessage.Text = "A user with that username already exists";
                return;
            }
            //already exisiting email adress
            user = getUserByEmail(signUpEmailEntry.Text);
            if (user != null)
            {
                signUpErrorMessage.Text = "A user with that email already exists";
                return;
            }


            var salt = Program.GetSalt();
            var email = this.signUpEmailEntry.Text;
            var username = this.signUpUsernameEntry.Text;
            var hashed_pw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: signUpPasswordEntry.Text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Program.User newUser = new Program.User();
            newUser.Email = email;
            newUser.Username = username;
            newUser.Hashed_pw = hashed_pw;
            newUser.Salt = salt;
            newUser.PerfectPitchLevel = 1;
            newUser.SignatureIdentificationLevel = 1;
            newUser.SignatureConstructionLevel = 1;

            Program.AddUserToDB(newUser);

            this.Hide();
            Program.loginScreen.Show();
        }
    }
}
