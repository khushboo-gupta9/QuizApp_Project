using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApplication
{
    public partial class setexams : Form
    {
        public setexams()
        {
            InitializeComponent();
        }

        private void setexams_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quizAppDataSet1.student_record' table. You can move, or remove it, as needed.


            this.student_recordTableAdapter.Fill(quizAppDataSet1.student_record);
            string q = "select * from student_record";
            viewclass vc = new viewclass(q);
            //vc.showrecord();

            //q = "select  distinct batch_code from student_record";
            //viewclass vc2 = new viewclass(q);

            dataGridView1.DataSource = vc.showrecord();
            SqlDataAdapter adapter = new SqlDataAdapter("select distinct batch_code from student_record", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\khush\source\repos\ExamApplication\quizApp.mdf;Integrated Security=True");
            DataSet dSet = new DataSet();
            adapter.Fill(dSet);
            comboBox1.DataSource = dSet.Tables[0];    
            comboBox1.DisplayMember = "batch_code";
            comboBox1.ValueMember = "batch_code";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
