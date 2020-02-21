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

        private void signUpButton_Click(object sender, EventArgs e)
        {
            var salt = Program.GetSalt();
            var email = this.signUpEmailEntry.Text;
            var username = this.signUpUsernameEntry.Text;
            var hashed_pw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: this.signUpPasswordEntry.Text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Program.User newUser = new Program.User();
            newUser.Email = email;
            newUser.Username = username;
            newUser.Hashed_pw = hashed_pw;
            newUser.Salt = salt;
            newUser.Score1 = 0;
            newUser.Score2 = 0;
            newUser.Score3 = 0;

            Program.AddUserToDB(newUser);

            this.Hide();
            Program.loginScreen.Show();
        }
    }
}
