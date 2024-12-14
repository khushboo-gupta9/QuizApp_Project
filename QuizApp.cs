using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApplication
{
    public partial class QuizApp : Form
    {
        public QuizApp()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Lastpa a = new Lastpa();

            a.Show();
           // this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void QuizApp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Studentlogin a = new Studentlogin();

            a.Show();
           // this.Hide();

        }
    }
}
