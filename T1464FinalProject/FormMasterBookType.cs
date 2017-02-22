using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1464FinalProject {
    public partial class FormMasterBookType : Form {
        DatabaseConnect con;

        /// <summary>
        /// 0 = initial, 1 = insert, 2 = update, 3 = delete.
        /// </summary>
        private int mode;

        public FormMasterBookType() {
            con = new DatabaseConnect();
            InitializeComponent();
            RefreshTable();
        }

        /// <summary>
        /// Refreshes DataGridView with SQL query.
        /// </summary>
        private void RefreshTable() {
            string query = "SELECT * FROM MsBookType";
            dataGridView1.DataSource = con.GetTable(query);
        }

        /// <summary>
        /// Generates a unique, incremental ID for each call.
        /// </summary>
        private void GenerateID() {
            int id;
            DataTable dt = con.GetTable("SELECT BookTypeID FROM MsBookType ORDER BY BookTypeID DESC");
            if (dt.Rows.Count > 1) {
                Int32.TryParse(((String)dt.Rows[0][0]).Substring(4), out id);

                string res = "BT" + (id + 1).ToString("000");
                Console.WriteLine("Generated " + res);
                txtID.Text = res;
            }
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
            }
            dataGridView1.Enabled = true;
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
            }
            txtID.Enabled = false;
            dataGridView1.Enabled = false;
        }

        /// <summary>
        /// Default Controls state for Update mode.
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
        /// Default Controls state for Delete mode.
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
            }
        }

        private void InsertDatabase() {
            try {
                string query = "INSERT INTO MsBookType VALUES ('" + txtID.Text + "','" + txtName.Text + "')";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDatabase() {
            try {
                string query = "UPDATE MsBookType SET BookTypeName='" + txtName.Text + "' WHERE BookTypeID='" + txtName.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDatabase() {
            try {
                string query = "DELETE FROM MsBookType WHERE BookTypeID='" + txtID.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateEmpty() {
            int c = 0;

            foreach (Control item in tableLayoutPanelInner.Controls) {
                if (item.GetType() == typeof(TextBox)) {
                    if (((TextBox)item).Text == string.Empty) {
                        c++;
                    }
                }
            }

            if (c != 0)
                MessageBox.Show(null, "Field must not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            return c == 0;
        }

        private void FormMasterBookType_Load(object sender, EventArgs e) {
            InitialState();
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
                case 1: // insert
                    if (ValidateEmpty()) {
                        InsertDatabase();
                    }
                    break;

                case 2: // update
                    if (ValidateEmpty()) {
                        UpdateDatabase();
                        MessageBox.Show(null, "Entry successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                default: // no state (should never happen)  
                    MessageBox.Show(null, "Invalid state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            ClearForms();
            InitialState();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtID.Text = (string)row.Cells["BookTypeID"].Value;
                txtName.Text = (string)row.Cells["BookTypeName"].Value;
            }
        }
    }
}
