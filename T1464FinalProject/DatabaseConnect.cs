using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace T1464FinalProject {
    class DatabaseConnect {
        SqlConnection con;

        /// <summary>
        /// SQL connection string
        /// </summary>
        public static string sql_connection_string = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + @"\Database1.mdf;Integrated Security=True;User Instance=True";

        public DatabaseConnect() {
            try {
                con = new SqlConnection(sql_connection_string);
                con.Open();
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetTable(String query) {
            SqlDataAdapter table = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            table.Fill(dt);
            con.Close();
            return dt;
        }

        public void ExecuteUpdate(String query) {
            try {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
