using System;
using System.Windows.Forms;

namespace ExamApplication
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
        }
        int startP = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            progressBar1.Value = startP;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                QuizApp q=new QuizApp();
                q.Show();
               this.Hide();
            }
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
