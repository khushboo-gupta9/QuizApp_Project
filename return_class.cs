using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamApplication
{
    internal class ReturnClass
    {
        private string conn_string = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        public string ScalarReturn(string q)
        {
            string s = string.Empty;  // Initialize the variable to avoid uninitialized errors
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(q, conn);
                    object result = cmd.ExecuteScalar();
                    s = result != null ? result.ToString() : string.Empty;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while executing the query: " + ex.Message);
                }
            }
            return s;
        }
    }
}
