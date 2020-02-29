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
        int numCorrect;
        int numCorrectInCurrentLevel;
        int numQuestionsAnswered;
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
            level = getLevel();
            levelLabel.Text = String.Format("Level: {0}", level);
            Console.WriteLine(level);
        }

        int getLevel()
        {
            return Program.db.Table<Program.User>().Where(user => user.Id.Equals(Program.userId)).First().SignatureIdentificationLevel;
        }

        void updateDatabaseLevel(int lvl)
        {
            Program.User user = Program.db.Table<Program.User>().Where(u => u.Id.Equals(Program.userId)).First();
            user.SignatureIdentificationLevel = lvl;
            Program.db.Update(user);
        }
        string getRandomSignature()
        {
            int numSignatures = Program.signatures.Count;
            signatureAnswer = new Random().Next(numSignatures);

            return Program.signatures[signatureAnswer];
        }
        void updateSignature(string signature)
        {
            questionSignatureImage.Image = System.Drawing.Image.FromFile(Program.getSignatureFile(signature));
        }
        void checkAnswer(string answer)
        {
            hasAnswered = true;

            if (answer == currentSignature)
            {
                numCorrect++;
                numCorrectInCurrentLevel++;
            }

            numQuestionsAnswered++;

            correctFraction.Text = String.Format("Correct: {0}/{1}", numCorrect, numQuestionsAnswered);
            correctLabel.Text = String.Format("The correct signature was: {0}", currentSignature);

            if (numCorrectInCurrentLevel > 10 && (float)numCorrectInCurrentLevel / numQuestionsAnswered > 0.7)
            {
                level++;
                numCorrectInCurrentLevel = 0;
                updateDatabaseLevel(level);
                levelLabel.Text = String.Format("Level: {0}", level);
                Console.WriteLine(getLevel());

            }
        }
        private void keySignatureIdentificationScreen_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("C_Major");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("D_Major");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("E_Major");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("F_Major");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("G_Major");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("A_Major");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("B_Major");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button3.Show();
            currentSignature = getRandomSignature();
            updateSignature(currentSignature);
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
                currentSignature = getRandomSignature();
                updateSignature(currentSignature);
                correctLabel.Text = "";
                hasAnswered = false;
            }
        }

        private void questionSignatureImage_Click(object sender, EventArgs e)
        {

        }
    }
}
