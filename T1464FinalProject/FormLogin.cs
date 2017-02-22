using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T1464FinalProject {
    public partial class FormLogin : Form {

        public int result;

        public int mode = 0;

        public string employeeID;

        public string employeeName;

        public string employeeRole;

        // returns the count of users with a specific username and password
        string query = @"SELECT Count(*) FROM MsEmployee WHERE Email = @Email AND Password = @Password";

        // if logged in, get the EmployeeID
        string queryGetID = @"SELECT EmployeeID, Name, Role FROM MsEmployee WHERE Email = @Email";

        FormMain main = new FormMain();

        public FormLogin() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (txtUsername.Text != "" && txtPassword.Text != "") {
                // enclosed in a using statement for later disposal
                using (SqlConnection cn = new SqlConnection(DatabaseConnect.sql_connection_string))
                using (SqlCommand cmd = new SqlCommand(query, cn)) {
                    try {
                        cn.Open();

                        // switches the @Email and @Password values with the ones in their respective TextBoxes
                        cmd.Parameters.AddWithValue("@Email", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        //Executes the query and returns the first result
                        result = (int)cmd.ExecuteScalar();
                        if (result > 0) {
                            MessageBox.Show("Succesfully logged in");
                            using (var connection = new SqlConnection(DatabaseConnect.sql_connection_string))
                            using (var command = new SqlCommand(queryGetID, connection))
                            {
                                command.Parameters.AddWithValue("@Email", txtUsername.Text);
                                connection.Open();
                                using (var reader = command.ExecuteReader())
                                {
                                    //Check the reader has data:
                                    if (reader.Read())
                                    {
                                        employeeID = reader.GetString(reader.GetOrdinal("EmployeeID"));
                                        employeeName = reader.GetString(reader.GetOrdinal("Name"));
                                        employeeRole = reader.GetString(reader.GetOrdinal("Role"));
                                    }
                                }
                            }
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                            if (employeeRole == "Admin")
                                mode = 1;
                            else
                                mode = 2;
                            cn.Close();
                        } else {
                            MessageBox.Show("Username/password incorrect");
                            cn.Close();
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(null, ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(null, "Please enter a username and/or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
