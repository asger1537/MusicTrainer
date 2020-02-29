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
    public partial class keySignatureIdentificationScreen : Form
    {
        string currentSignature;
        int numCorrect, numCorrectInCurrentLevel;
        int numQuestionsAnswered, numQuestionsAnsweredInCurrentLevel;
        bool hasAnswered;
        int level;
        int signatureAnswer;
        public keySignatureIdentificationScreen()
        {
            InitializeComponent();
        }
        public void initializeSignatureIdentification()
        {
            hasAnswered = false;
            numCorrect = numCorrectInCurrentLevel = numQuestionsAnswered = 0;
            level = GetLevel();
            levelLabel.Text = String.Format("Level: {0}", level);
        }

        int GetLevel()
        {
            return Program.db.Table<Program.User>().Where(user => user.Id.Equals(Program.userId)).First().SignatureIdentificationLevel;
        }

        void UpdateDatabaseLevel(int lvl)
        {
            Program.User user = Program.db.Table<Program.User>().Where(u => u.Id.Equals(Program.userId)).First();
            user.SignatureIdentificationLevel = lvl;
            Program.db.Update(user);
        }

        string GetRandomSignature()
        {
            int numSignatures = Program.signatures.Count;
            signatureAnswer = new Random().Next(numSignatures);

            return Program.signatures[signatureAnswer];
        }

        void UpdateSignature(string signature)
        {
            questionSignatureImage.Image = System.Drawing.Image.FromFile(Program.getSignatureFile(signature));
        }

        void CheckAnswer(string answer)
        {
            hasAnswered = true;

            if (answer == currentSignature)
            {
                numCorrect++;
                numCorrectInCurrentLevel++;
            }

            numQuestionsAnswered++;
            numQuestionsAnsweredInCurrentLevel++;

            correctFraction.Text = String.Format("Correct: {0}/{1}", numCorrect, numQuestionsAnswered);
            correctLabel.Text = String.Format("The correct signature was: {0}", currentSignature);

            if (numCorrectInCurrentLevel > 10 && (float)numCorrectInCurrentLevel / numQuestionsAnsweredInCurrentLevel > 0.7)
            {
                LevelUp();
            }
        }

        void LevelUp()
        {
            level++;
            numCorrectInCurrentLevel = 0;
            numQuestionsAnsweredInCurrentLevel = 0;
            UpdateDatabaseLevel(level);
            levelLabel.Text = String.Format("Level: {0}", level);
        }

        private void C_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("C_Major");
        }

        private void D_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("D_Major");
        }

        private void E_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("E_Major");
        }

        private void F_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("F_Major");
        }

        private void G_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("G_Major");
        }

        private void A_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("A_Major");
        }

        private void B_MajorButton_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) CheckAnswer("B_Major");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            ContinueButton.Show();
            currentSignature = GetRandomSignature();
            UpdateSignature(currentSignature);
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
                currentSignature = GetRandomSignature();
                UpdateSignature(currentSignature);
                correctLabel.Text = "";
                hasAnswered = false;
            }
        }
    }
}
