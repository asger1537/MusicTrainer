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
    public partial class perfectPitchScreen : Form
    {
        string currentNote;

        public perfectPitchScreen()
        {
            InitializeComponent();
            currentNote = getRandomNote();
        }

        string getRandomNote()
        {

            List<string> notes = new List<string>() { "C", "D", "E", "F", "G", "A", "B" };

            return notes[new Random().Next(notes.Count)];
        }

        private void perfectPitchScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void HearAgain_Click(object sender, EventArgs e)
        {
            Program.tonePlayers[currentNote].Play();
        }
    }
}
