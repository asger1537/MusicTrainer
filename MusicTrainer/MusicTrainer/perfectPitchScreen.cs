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
        int numCorrect;
        int numQuestionsAnswered;
        bool hasAnswered;

        public perfectPitchScreen()
        {
            InitializeComponent();
        }

        public void initializePerfectpitch()
        {
            hasAnswered = false;
            numCorrect = 0;
            numQuestionsAnswered = 0;
            currentNote = getRandomNote();
            updateNotePlayer(currentNote);
        }

        string getRandomNote()
        {
            return Program.notes[new Random().Next(Program.notes.Count)];
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
            currentNote = getRandomNote();
            updateNotePlayer(currentNote);
            Program.notePlayer.controls.play();
            correctLabel.Text = "";
            hasAnswered = false;
        }

        private void HearAgain_Click(object sender, EventArgs e)
        {
            Program.notePlayer.controls.play();
        }

        void checkAnswer(string answer)
        {
            hasAnswered = true;

            if (answer == currentNote)
            {
                numCorrect++;
            }

            numQuestionsAnswered++;

            correctFraction.Text = String.Format("Correct: {0}/{1}", numCorrect, numQuestionsAnswered);
            correctLabel.Text = String.Format("The correct note was: {0}", currentNote);
        }

        void updateNotePlayer(string note)
        {
            Program.notePlayer.URL = Program.getNoteFile(note);
        }

        private void answerKeySignatureAButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("A3");
        }

        private void answerKeySignatureBButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("B3");
        }

        private void answerKeySignatureCButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("C3");
        }

        private void answerKeySignatureDButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("D3");
        }

        private void answerKeySignatureEButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("E3");
        }

        private void answerKeySignatureFButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("F3");
        }

        private void answerKeySignatureGButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("G3");
        }
    }
}
