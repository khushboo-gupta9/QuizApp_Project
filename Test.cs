using System;
using System.Windows.Forms;

namespace ExamApplication
{
    public partial class Test : Form
    {
        int i, score = 0;
        string correctop;

        public Test()
        {
            InitializeComponent();
        }

        ReturnClass rc = new ReturnClass();

        public void SetUsername(string username)
        {
            // Set the username to label6 on the Test form
            label6.Text = username;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            label4.Text = score.ToString();  // Display the initial score
            i = Convert.ToInt32(rc.ScalarReturn("select min(que_id) from tabl_question"));
            LoadQuestion(i);
        }

        private void LoadQuestion(int questionId)
        {
            label1.Text = rc.ScalarReturn($"SELECT q_title FROM tabl_question WHERE que_id = {questionId}");
            radioButton1.Text = rc.ScalarReturn($"SELECT q_opA FROM tabl_question WHERE que_id = {questionId}");
            radioButton2.Text = rc.ScalarReturn($"SELECT q_opB FROM tabl_question WHERE que_id = {questionId}");
            radioButton3.Text = rc.ScalarReturn($"SELECT q_opC FROM tabl_question WHERE que_id = {questionId}");
            radioButton4.Text = rc.ScalarReturn($"SELECT q_opD FROM tabl_question WHERE que_id = {questionId}");
            correctop = rc.ScalarReturn($"SELECT q_correctOption FROM tabl_question WHERE que_id = {questionId}");
        }

        private void button2_Click(object sender, EventArgs e)  // Next button
        {
            string selectedvalue = GetSelectedOption();

            if (selectedvalue == null)
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            if (selectedvalue.Equals(correctop))
            {
                score++;
                label4.Text = score.ToString();  // Update the score
            }

            string nextQuestion = rc.ScalarReturn($"select min(que_id) from tabl_question where que_id > {i}");

            if (string.IsNullOrEmpty(nextQuestion))
            {
                MessageBox.Show("Quiz Over!");
                button2.Enabled = false;
            }
            else
            {
                i = Convert.ToInt32(nextQuestion);
                LoadQuestion(i);
                radiobtn();
            }
        }

        private string GetSelectedOption()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            if (radioButton2.Checked) return radioButton2.Text;
            if (radioButton3.Checked) return radioButton3.Text;
            if (radioButton4.Checked) return radioButton4.Text;
            return null;
        }

        private void radiobtn()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)  // Previous button
        {
            string prevQuestion = rc.ScalarReturn($"select max(que_id) from tabl_question where que_id < {i}");

            if (string.IsNullOrEmpty(prevQuestion))
            {
                MessageBox.Show("This is the first question.");
            }
            else
            {
                i = Convert.ToInt32(prevQuestion);
                LoadQuestion(i);
                radiobtn();
            }
        }

        private void button3_Click(object sender, EventArgs e)  // Submit button
        {
            MessageBox.Show("Final score: " + score.ToString());
            Endpage endPage = new Endpage(score);  // Pass the score to Endpage
            endPage.Show();
            this.Hide();  // Hide the quiz form
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)  // Logout button
        {
            QuizApp quizApp = new QuizApp();
            quizApp.Show();
            this.Hide();  // Go back to the login page
        }
    }
}
