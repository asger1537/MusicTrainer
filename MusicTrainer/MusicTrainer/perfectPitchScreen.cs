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
    public partial class PerfectPitchScreen : Form
    {
        string currentNote;
        int numCorrect, numCorrectInCurrentLevel;
        int numQuestionsAnswered, numQuestionsAnsweredInCurrentLevel;
        bool hasAnswered;
        int level;

        public PerfectPitchScreen()
        {
            InitializeComponent();
        }

        public void initializePerfectpitch()
        {
            hasAnswered = false;
            numCorrect = numCorrectInCurrentLevel = numQuestionsAnswered = numQuestionsAnsweredInCurrentLevel = 0;
            level = getLevel();
            levelLabel.Text = String.Format("Level: {0}", level);
            Console.WriteLine(level);
            currentNote = getRandomNote();
            UpdateNotePlayer(currentNote);
        }

        int getLevel()
        {
            return Program.db.Table<Program.User>().Where(user => user.Id.Equals(Program.userId)).First().PerfectPitchLevel;
        }

        void updateDatabaseLevel(int lvl)
        {
            Program.User user = Program.db.Table<Program.User>().Where(u => u.Id.Equals(Program.userId)).First();
            user.PerfectPitchLevel = lvl;
            Program.db.Update(user);
        }

        string getRandomNote()
        {
            int numNotes = level + 1 > Program.notes.Count ? Program.notes.Count : level + 1;
            return Program.notes[new Random().Next(numNotes)];
        }

        private void perfectPitchScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.selectionScreen.Show();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (hasAnswered)
            {
                currentNote = getRandomNote();
                UpdateNotePlayer(currentNote);
                Program.notePlayer.controls.play();
                correctLabel.Text = "";
                hasAnswered = false;
            }
        }

        private void HearAgain_Click(object sender, EventArgs e)
        {
            Program.notePlayer.controls.play();
        }

        void CheckAnswer(string answer)
        {
            hasAnswered = true;

            if (answer == currentNote)
            {
                numCorrect++;
                numCorrectInCurrentLevel++;
            }

            numQuestionsAnswered++;
            numQuestionsAnsweredInCurrentLevel++;

            correctFraction.Text = String.Format("Correct: {0}/{1}", numCorrect, numQuestionsAnswered);
            correctLabel.Text = String.Format("The correct note was: {0}", currentNote);

            if (numCorrectInCurrentLevel > 10 && (float)numCorrectInCurrentLevel/numQuestionsAnsweredInCurrentLevel > 0.7)
            {
                LevelUp();
            }
        }

        void LevelUp()
        {
            level++;
            numCorrectInCurrentLevel = 0;
            numQuestionsAnsweredInCurrentLevel = 0;
            updateDatabaseLevel(level);
            levelLabel.Text = String.Format("Level: {0}", level);
        }

        void UpdateNotePlayer(string note)
        {
            Program.notePlayer.URL = Program.GetNoteFile(note);
        }

        private void AnswerAButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("A3");
        }

        private void AnswerBButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("B3");
        }

        private void AnswerCButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("C3");
        }

        private void AnswerDButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("D3");
        }

        private void AnswerEButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("E3");
        }

        private void AnswerFButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("F3");
        }

        private void AnswerGButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("G3");
        }
    }
}
