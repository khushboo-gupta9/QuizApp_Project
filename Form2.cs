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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_Question a = new Add_Question();

            a.Show();
           // this.Hide(); // Hide 


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Studentlogin a = new Studentlogin();
            a.Show();
            //this.Hide(); // Hide 


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            setexams se = new setexams();
            se.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
