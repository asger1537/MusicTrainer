﻿using System;
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
        int numCorrect;
        int numCorrectInCurrentLevel;
        int numQuestionsAnswered;
        bool hasAnswered;
        int level;

        public PerfectPitchScreen()
        {
            InitializeComponent();
        }

        public void initializePerfectpitch()
        {
            hasAnswered = false;
            numCorrect = numCorrectInCurrentLevel = numQuestionsAnswered = 0;
            level = getLevel();
            levelLabel.Text = String.Format("Level: {0}", level);
            Console.WriteLine(level);
            currentNote = getRandomNote();
            updateNotePlayer(currentNote);
        }

        int getLevel()
        {
            return Program.DB.Table<Program.User>().Where(user => user.Id.Equals(Program.userId)).First().PerfectPitchLevel;
        }

        void updateDatabaseLevel(int lvl)
        {
            Program.User user = Program.DB.Table<Program.User>().Where(u => u.Id.Equals(Program.userId)).First();
            user.PerfectPitchLevel = lvl;
            Program.DB.Update(user);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.selectionScreen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hasAnswered)
            {
                currentNote = getRandomNote();
                updateNotePlayer(currentNote);
                Program.notePlayer.controls.play();
                correctLabel.Text = "";
                hasAnswered = false;
            }
        }

        }

        void checkAnswer(string answer)
        {
            hasAnswered = true;

            if (answer == currentNote)
            {
                numCorrect++;
                numCorrectInCurrentLevel++;
            }

            numQuestionsAnswered++;

            correctFraction.Text = String.Format("Correct: {0}/{1}", numCorrect, numQuestionsAnswered);
            correctLabel.Text = String.Format("The correct note was: {0}", currentNote);

            if (numCorrectInCurrentLevel > 10 && (float)numCorrectInCurrentLevel/numQuestionsAnswered > 0.7)
            {
                level++;
                numCorrectInCurrentLevel = 0;
                updateDatabaseLevel(level);
                levelLabel.Text = String.Format("Level: {0}", level);
                Console.WriteLine(getLevel());
            }
        }

        void updateNotePlayer(string note)
        {
            Program.notePlayer.URL = Program.GetNoteFile(note);
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

        }
    }
}
