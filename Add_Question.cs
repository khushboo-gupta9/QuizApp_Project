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
    public partial class Add_Question : Form
    {
        public Add_Question()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Question_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quizAppDataSet.tbl_exams' table. You can move, or remove it, as needed.
            this.tbl_examsTableAdapter.Fill(this.quizAppDataSet.tbl_exams);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.SelectedValue.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the Questions class and populate it with data from form inputs
            Questions q = new Questions();
            q.q_title = textBox1.Text;
            q.q_opA = textBox2.Text;
            q.q_opB = textBox3.Text;
            q.q_opC = textBox4.Text;
            q.q_opD = textBox5.Text;
            q.q_correctOption = textBox6.Text;
            q.q_correctData = System.DateTime.Now.ToString("MM/dd/yyyy");
            q.ad_id_fk = Convert.ToInt32(Lastpa.fk_ad);
            q.ex_id_fk = Convert.ToInt32(comboBox1.SelectedValue);

            // Create an instance of Insertclass and call the insert_records method
            Insertclass ic = new Insertclass();
            string msg = ic.insert_records(q);

            // Show a message box with the result of the operation
            MessageBox.Show(msg);
        }
    }
}