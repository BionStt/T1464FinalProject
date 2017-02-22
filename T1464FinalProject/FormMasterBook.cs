using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1464FinalProject {
    public partial class FormMasterBook : Form {
        DatabaseConnect con;

        private int mode = 0;

        public FormMasterBook() {
            con = new DatabaseConnect();
            InitializeComponent();
            RefreshTable();

        }

        private void RefreshTable() {
            string query = "SELECT * FROM MsBook";
            dataGridView1.DataSource = con.GetTable(query);
        }

        private void GenerateID() {
            int id;
            DataTable dt = con.GetTable("SELECT BookID FROM MSBook ORDER BY BookID DESC");
            if (dt.Rows.Count > 1) {
                Int32.TryParse(((String)dt.Rows[0][0]).Substring(4), out id);
                txtBookID.Text = "BO" + (id + 1).ToString("000");
            }
        }

        private void InitialState() {
            try {
                mode = 0;
                btnInsert.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                foreach (Control item in tableLayoutPanelControls.Controls) {
                    if (item.GetType() == typeof(TextBox))
                        ((TextBox)item).Enabled = false;
                    if (item.GetType() == typeof(ComboBox))
                        ((ComboBox)item).Enabled = false;
                    if (item.GetType() == typeof(NumericUpDown))
                        ((NumericUpDown)item).Enabled = false;
                }
                dataGridView1.Enabled = true;
                cbxBookTypeID.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void InsertState() {
            try {
                mode = 1;

                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                foreach (Control item in tableLayoutPanelControls.Controls) {
                    if (item.GetType() == typeof(TextBox))
                        ((TextBox)item).Enabled = true;
                    if (item.GetType() == typeof(ComboBox))
                        ((ComboBox)item).Enabled = true;
                    if (item.GetType() == typeof(NumericUpDown))
                        ((NumericUpDown)item).Enabled = true;
                }
                txtBookID.Enabled = false;
                dataGridView1.Enabled = true;
                cbxBookTypeID.SelectedIndex = 0;
            } catch (Exception) {

            }


        }

        private void UpdateState() {

            try {
                mode = 2;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                foreach (Control item in tableLayoutPanelControls.Controls) {
                    if (item.GetType() == typeof(TextBox))
                        ((TextBox)item).Enabled = true;
                    if (item.GetType() == typeof(ComboBox))
                        ((ComboBox)item).Enabled = true;
                    if (item.GetType() == typeof(NumericUpDown))
                        ((NumericUpDown)item).Enabled = true;
                }
                txtBookID.Enabled = false;
                //txBookTypeID.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteState() {
            try {
                mode = 3;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                foreach (Control item in tableLayoutPanelControls.Controls) {
                    if (item.GetType() == typeof(TextBox))
                        ((TextBox)item).Enabled = true;
                    if (item.GetType() == typeof(ComboBox))
                        ((ComboBox)item).Enabled = true;
                    if (item.GetType() == typeof(NumericUpDown))
                        ((NumericUpDown)item).Enabled = true;
                }
                txtBookID.Enabled = false;
                dataGridView1.Enabled = true;
                cbxBookTypeID.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearForms() {
            try {
                foreach (Control item in tableLayoutPanelControls.Controls) {
                    if (item.GetType() == typeof(TextBox))
                        ((TextBox)item).Text = string.Empty;
                    if (item.GetType() == typeof(ComboBox))
                        ((ComboBox)item).SelectedIndex = 0;
                    if (item.GetType() == typeof(NumericUpDown))
                        ((NumericUpDown)item).Value = 1;
                }
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDatabase() {
            try {
                string query = "INSERT INTO MsBook VALUES ('" + txtBookID.Text + "','" + txtBookTitle.Text + "','" + cbxBookTypeID.Text + "'," + txtPrice.Text + "," + numTotalPage.Value.ToString() + ",'" + txtAuthor.Text + "','" + txtPublisher.Text + "','" + txtISBN.Text + "'," + numStock.Value.ToString() + ")";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDatabase() {
            try {
                string query = "UPDATE MsBook SET BookTitle='" + txtBookTitle.Text + "',BookTypeID='" + cbxBookTypeID.Text + "',Price=" + txtPrice.Text + ",TotalPage = " + numTotalPage.Value.ToString() + ", Author ='" + txtAuthor.Text + "',Publisher= '" + txtPublisher.Text + "', ISBN = '" + txtISBN.Text + "',Stock = " + numStock.Value.ToString() + " WHERE BookID='" + txtBookID.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDatabase() {
            try {
                string query = "DELETE FROM MsBook WHERE BookID='" + txtBookID.Text + "'";
                con.ExecuteUpdate(query);
            } catch (Exception ex) {
                MessageBox.Show(null, ex.ToString(), "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateEmpty() {
            int c = 0;

            foreach (Control item in tableLayoutPanelControls.Controls) {
                if (item.GetType() == typeof(TextBox)) {
                    if (((TextBox)item).Text == string.Empty) {
                        c++;
                    }
                }
                if (item.GetType() == typeof(ComboBox)) {
                    if (((ComboBox)item).SelectedIndex == 0) {
                        c++;
                    }
                }
                if (item.GetType() == typeof(NumericUpDown)) {
                    if (((NumericUpDown)item).Value < 1) {
                        c++;
                    }
                }
            }

            if (c != 0) {
                MessageBox.Show(null, "Field must not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            return c == 0;
        }

        private void FormMasterBook_Load(object sender, EventArgs e) {
            InitialState();
        }

        private void btnInsert_Click(object sender, EventArgs e) {

            ClearForms();
            GenerateID();

            InsertState();
            mode = 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            if (txtBookID.Text == string.Empty) {
                MessageBox.Show(null, "No data selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else {
                UpdateState();
                mode = 2;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {


            //DeleteState();
            mode = 3;
            if (txtBookID.Text == string.Empty) {
                MessageBox.Show(null, "No data selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else {
                if (MessageBox.Show(null, "Are you sure you want to delete " + txtBookID.Text + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    DeleteDatabase();
            }
            RefreshTable();
            ClearForms();
            InitialState();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtBookID.Text = (string)row.Cells["BookID"].Value;
                txtBookTitle.Text = (string)row.Cells["BookTitle"].Value;

                switch ((string)row.Cells["BookTypeID"].Value) {
                    case "BT001":
                        cbxBookTypeID.SelectedIndex = 1;
                        break;

                    case "BT002":
                        cbxBookTypeID.SelectedIndex = 2;
                        break;

                    case "BT003":
                        cbxBookTypeID.SelectedIndex = 3;
                        break;

                    case "BT004":
                        cbxBookTypeID.SelectedIndex = 4;
                        break;

                    default:
                        break;
                }

                txtAuthor.Text = (string)row.Cells["Author"].Value;
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                numTotalPage.Value = (int)row.Cells["TotalPage"].Value;
                txtPublisher.Text = (string)row.Cells["Publisher"].Value;
                txtISBN.Text = (string)row.Cells["ISBN"].Value;
                numStock.Value = (int)row.Cells["Stock"].Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            switch (mode) {
                case 1: // Insert
                    if (ValidateEmpty())
                        InsertDatabase();
                    break;
                case 2: // Update
                    if (ValidateEmpty())
                        UpdateDatabase();
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
            InitialState();
            ClearForms();
        }

        private void cbxBookTypeID_SelectedIndexChanged(object sender, EventArgs e) {
            switch (cbxBookTypeID.SelectedIndex) {
                case 1:
                    lblBookTypeName.Text = "Factual";
                    break;

                case 2:
                    lblBookTypeName.Text = "Comic";
                    break;

                case 3:
                    lblBookTypeName.Text = "Horror";
                    break;

                case 4:
                    lblBookTypeName.Text = "Fiction";
                    break;

                default:
                    lblBookTypeName.Text = "Select a book type.";
                    break;
            }
        }
    }
}
