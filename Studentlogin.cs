using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApplication
{
    public partial class Studentlogin : Form
    {
        public Studentlogin()
        {
            InitializeComponent();
        }

        // LOGIN BUTTON CODE
        // LOGIN BUTTON CODE
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string batchcode = textBox2.Text;
            string password = textBox3.Text;
            string adid = textBox4.Text;

            ReturnClass rc = new ReturnClass();
            string query = "SELECT std_password, batch_code, ad_id_fk FROM student_record WHERE std_name=@name";
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\khush\\source\\repos\\ExamApplication\\quizApp.mdf;Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // if user exists
                    {
                        string passworddb = reader["std_password"].ToString();
                        string batchdb = reader["batch_code"].ToString();
                        string adiddb = reader["ad_id_fk"].ToString();

                        if (passworddb.Equals(password) && batchdb.Equals(batchcode) && adiddb.Equals(adid))
                        {
                            // Instantiate the Test form
                            Test testForm = new Test();

                            // Pass the username to the Test form
                            testForm.SetUsername(name);

                            // Show the Test form and hide the login form
                            testForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login details. Please check the password, batch code, or admission ID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        // REGISTER BUTTON CODE
        private void button2_Click_1(object sender, EventArgs e)
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\khush\\source\\repos\\ExamApplication\\quizApp.mdf;Integrated Security=True";
            string query = "INSERT INTO student_record (std_name, batch_code, std_password, ad_id_fk) VALUES (@std_name, @batch_code, @std_password, @ad_id_fk)";

            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Set parameters
                    cmd.Parameters.AddWithValue("@std_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@batch_code", textBox2.Text);
                    cmd.Parameters.AddWithValue("@std_password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@ad_id_fk", textBox4.Text);

                    // Execute query
                    int result = cmd.ExecuteNonQuery(); // Use ExecuteNonQuery for INSERT

                    // Check if the insert was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Registration Successful");
                        Test testForm = new Test();
                        testForm.SetUsername(textBox1.Text);  // Pass the registered name to Test form
                        testForm.Show();
                        this.Hide();  // Hide the registration form
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
