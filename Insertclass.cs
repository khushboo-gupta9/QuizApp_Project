using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamApplication
{
    internal class Insertclass
    {
        private string conn_string = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
        //inseting Question........
        public string insert_records(Questions q)
        {
            {
                string msg = "";
                SqlConnection conn = new SqlConnection(conn_string);
                try
                {
                    SqlCommand cmd = new SqlCommand("insert_ques", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@q_title", SqlDbType.VarChar).Value = q.q_title;
                    cmd.Parameters.Add("@q_opA", SqlDbType.VarChar).Value = q.q_opA;
                    cmd.Parameters.Add("@q_opB", SqlDbType.VarChar).Value = q.q_opB;
                    cmd.Parameters.Add("@q_opC", SqlDbType.VarChar).Value = q.q_opC;
                    cmd.Parameters.Add("@q_opD", SqlDbType.VarChar).Value = q.q_opD;
                    cmd.Parameters.Add("@q_correctOption", SqlDbType.VarChar).Value =q.q_correctOption;
                    cmd.Parameters.Add("@q_correctData", SqlDbType.VarChar).Value = q.q_correctData;

                    cmd.Parameters.Add("@ad_id", SqlDbType.Int).Value = q.ad_id_fk;
                    cmd.Parameters.Add("@ex_id", SqlDbType.Int).Value = q.ex_id_fk;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = "Data Successfully Inserted";








                }
                catch (Exception ex)
                {
                    msg = "Data is not Successfully Inserted: " + ex.Message;
                }

                finally
                {
                    conn.Close();
                }
                return msg;

            }

        }




        //inseting Question........

    }
}
