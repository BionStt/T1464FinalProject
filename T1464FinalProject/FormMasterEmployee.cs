using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1464FinalProject {
    public partial class FormMasterEmployee : Form {
        // regex
        // ^[a-zA-Z]{5,}+@(yahoo.com|gmail.com)

        DatabaseConnect con;

        /// <summary>
        /// 0 = initial, 1 = insert, 2 = update, 3 = delete.
        /// </summary>
        private int mode = 0;

        private void GenerateID() {
            int id;
            DataTable dt = con.GetTable("SELECT EmployeeID FROM MSEMPLOYEE ORDER BY EmployeeID DESC");
            if (dt.Rows.Count > 1) {
                Int32.TryParse(((String)dt.Rows[0][0]).Substring(4), out id);

                string res = "EM" + (id + 1).ToString("000");
                Console.WriteLine("Generated " + res);
                txtID.Text = res;
            }
        }

        public FormMasterEmployee() {
            con = new DatabaseConnect();
            InitializeComponent();
            RefreshTable();
        }

        /// <summary>
        /// Initial state.
        /// </summary>
        private void InitialState() {
            mode = 0;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnSubmit.Enabled = false;
            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Enabled = false;
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).Enabled = false;
            }
            dataGridView1.Enabled = true;
            cbxRole.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes DataGridView with SQL query.
        /// </summary>
        private void RefreshTable() {
            string query = "SELECT * FROM MsEmployee";
            dataGridView1.DataSource = con.GetTable(query);
        }

        /// <summary>
        /// Default controls state for Insert mode.
        /// </summary>
        private void InsertState() {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnSubmit.Enabled = true;
            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Enabled = true;
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).Enabled = true;
            }
            txtID.Enabled = false;
            dataGridView1.Enabled = false;
        }

        /// <summary>
        /// Default controls state for Update mode.
        /// </summary>
        private void EditState() {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnSubmit.Enabled = true;
            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Enabled = true;
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).Enabled = true;
            }
            txtID.Enabled = false;
            dataGridView1.Enabled = true;
        }

        /// <summary>
        /// Default controls for Delete mode.
        /// </summary>
        private void DeleteState() {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnSubmit.Enabled = true;
            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Enabled = false;
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).Enabled = false;
            }
            dataGridView1.Enabled = true;
        }

        /// <summary>
        /// Clears all Control items within the form.
        /// </summary>
        private void ClearForms() {
            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Text = string.Empty;
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).SelectedIndex = 0;
            }
        }

        private void InsertDatabase() {
            try {
                string query = "INSERT INTO MsEmployee VALUES ('" + txtID.Text + "','" + txtName.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "','" + cbxRole.Text + "')";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDatabase() {
            try {
                string query = "UPDATE MsEmployee SET Name='" + txtName.Text + "',Email='" + txtEmail.Text + "',Password='" + txtPass.Text + "',Role = '" + cbxRole.Text + "' WHERE EmployeeID='" + txtID.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDatabase() {
            try {
                string query = "DELETE FROM MsEmployee WHERE EmployeeID='" + txtID.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateEmpty() {
            if (txtName.Text == string.Empty) {
                MessageBox.Show(null, "Name must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (txtID.Text == string.Empty) {
                MessageBox.Show(null, "Email must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else {
                return true;
            }
        }

        private bool ValidateEmail() {
            if (txtEmail.TextLength <= 10) {
                MessageBox.Show(null, "Email must be 10 characters minimum.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!txtEmail.Text.Contains(".")) {
                MessageBox.Show(null, "Email does not contain a period (.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if ((int)txtEmail.Text.Count(c => c == '@') != 1) {
                MessageBox.Show(null, "Email must contain exactly one (@)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!(txtEmail.Text.EndsWith("yahoo.com") || txtEmail.Text.EndsWith("gmail.com"))) {
                MessageBox.Show(null, "Email must be google or yahoo account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!(txtEmail.Text.IndexOf("@") < txtEmail.Text.IndexOf("."))) {
                MessageBox.Show(null, "Email (@) must be before (.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (txtEmail.Text.StartsWith("@") || txtEmail.Text.StartsWith(".") || txtEmail.Text.EndsWith("@") || txtEmail.Text.EndsWith(".")) {
                MessageBox.Show(null, "Email must not start or end with (@) or (.)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (txtEmail.Text.IndexOf(".") - txtEmail.Text.IndexOf("@") == 1) {
                MessageBox.Show(null, "(@) and (.) must not be side by side", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else {
                return true;
            }
        }

        private bool ValidatePassword() {
            if (txtPass.Text == string.Empty) {
                MessageBox.Show(null, "Password must not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (txtPass.Text.Length < 8) {
                MessageBox.Show(null, "Password must be more than 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (txtPass.Text.Contains(" ")) {
                MessageBox.Show(null, "Password must not contain space", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else {
                return true;
            }
        }

        private bool ValidateRole() {
            if (cbxRole.SelectedIndex > 2 || cbxRole.SelectedIndex < 1) {
                MessageBox.Show(null, "Role must be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else {
                return true;
            }
        }

        private void MasterEmployee_Load(object sender, EventArgs e) {
            InitialState();
            txtID.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e) {
            ClearForms();
            GenerateID();
            InsertState();
            mode = 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            EditState();
            mode = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            //DeleteState();
            mode = 3;
            if (txtID.Text == string.Empty) {
                MessageBox.Show(null, "No data selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else {
                if (MessageBox.Show(null, "Are you sure you want to delete " + txtID.Text + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    DeleteDatabase();
            }
            RefreshTable();
            ClearForms();
            InitialState();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            switch (mode) {
                case 1: // Insert
                    if (ValidateEmpty() && ValidateEmail() && ValidatePassword() && ValidateRole()) {
                        InsertDatabase();
                    }
                    break;

                case 2: // Update
                    if (ValidateEmpty() && ValidateEmail() && ValidatePassword() && ValidateRole()) {
                        UpdateDatabase();
                        MessageBox.Show(null, "Entry successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                default: // no Delete state as it's included in its button control.
                    MessageBox.Show(null, "Invalid state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            RefreshTable();
            ClearForms();
            InitialState();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            ClearForms();
            InitialState();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtID.Text = (string)row.Cells["EmployeeID"].Value;
                txtName.Text = (string)row.Cells["Name"].Value;
                //cbRole.SelectedIndex = row.Cells["Row"].Value;
                if ((string)row.Cells["Role"].Value == "Admin")
                    cbxRole.SelectedIndex = 1;
                else if ((string)row.Cells["Role"].Value == "ShopKeeper")
                    cbxRole.SelectedIndex = 2;
                txtEmail.Text = (string)row.Cells["Email"].Value;
                txtPass.Text = (string)row.Cells["Password"].Value;
            }
        }
    }
}
