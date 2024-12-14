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
    public partial class Lastpa : Form
    {
        public static string fk_ad;
        public Lastpa()
        {
            InitializeComponent();
        }

       
           
        private void button1_Click_1(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string password = textBox2.Text;
            string user_db, passworddb;

            ReturnClass rc = new ReturnClass();
            user_db = rc.ScalarReturn("select COUNT(ad_id) from tbl_admin where ad_name='" + user_name + "'");


            if (user_db.Equals("0"))
            {
                MessageBox.Show("Invalid Username");
            }
            else
            {
                passworddb = rc.ScalarReturn("select ad_password from tbl_admin where ad_name='" + user_name + "'");

                if (passworddb.Equals(password))
                {

                    fk_ad = rc.ScalarReturn("select ad_id from tbl_admin where ad_name='" + user_name + "'");

                    Form2 f = new Form2();
                    f.Show();
                   // this.Hide();




                }

                else
                {
                    MessageBox.Show("Invalid user password");
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

