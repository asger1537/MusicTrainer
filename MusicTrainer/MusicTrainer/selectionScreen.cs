using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicTrainer
{
    public partial class SelectionScreen : Form
    {
        public SelectionScreen()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void loginUsernameEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginPasswordEntry_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectionScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void perfectPitchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.perfectPitchScreen.Show();

            Program.perfectPitchScreen.initializePerfectpitch();
        }

        private void noteConstructionButton_Click(object sender, EventArgs e)
        {

        }
        //read keySignatureIdentificationButton_Click
        private void ScaleIdentificationButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.keySignatureIdentificationScreen.Show();
        }

        private void keySignatureConstructionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.keySignatureConstructionScreen.Show();
            Program.keySignatureConstructionScreen.InitializeKeySignatureConstruction();
        }
    }
}
