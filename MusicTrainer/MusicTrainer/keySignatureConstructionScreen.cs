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
    public partial class keySignatureConstructionScreen : Form
    {
        string currentSignature;
        int numCorrect;
        int numCorrectInCurrentLevel;
        int numQuestionsAnswered;
        bool hasAnswered;
        int level;
        public keySignatureConstructionScreen()
        {
            InitializeComponent();
        }
        public void initializeKeySignatureConstruction()
        {
            hasAnswered = false;
            numCorrect = numCorrectInCurrentLevel = numQuestionsAnswered = 0;
            level = getLevel();
            levelLabel.Text = String.Format("Level: {0}", level);
            Console.WriteLine(level);
        }

        int getLevel()
        {
            return Program.db.Table<Program.User>().Where(user => user.Id.Equals(Program.userId)).First().SignatureConstructionLevel;
        }

        void updateDatabaseLevel(int lvl)
        {
            Program.User user = Program.db.Table<Program.User>().Where(u => u.Id.Equals(Program.userId)).First();
            user.SignatureConstructionLevel = lvl;
            Program.db.Update(user);
        }
        string getRandomSignature()
        {
            int numSignatures = Program.signatures.Count;
            return Program.signatures[new Random().Next(numSignatures)];
        }
        void updateSignature(string signature)
        {
            questionSignatureLabel.Text = String.Format("{0}", signature);
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
            correctLabel.Text = String.Format("The correct note was: {0}", currentSignature);

            if (numCorrectInCurrentLevel > 10 && (float)numCorrectInCurrentLevel / numQuestionsAnswered > 0.7)
            {
                level++;
                numCorrectInCurrentLevel = 0;
                updateDatabaseLevel(level);
                levelLabel.Text = String.Format("Level: {0}", level);
                Console.WriteLine(getLevel());
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void keySignatureConstructionScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("C_Major");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button3.Show();
    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!hasAnswered)
            {
                currentSignature = getRandomSignature();
                updateSignature(currentSignature);
                //correctLabel.Text = "";
                hasAnswered = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.selectionScreen.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("F_Major");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("G_Major");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("D_Major");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("A_Major");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!hasAnswered) checkAnswer("E_Major");
        }
    }
}
