using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1464FinalProject {
    public partial class FormMain : Form {

        /// <summary>
        /// 0 = not logged in, 1 = logged in as admin, 2 = logged in as shopkeeper
        /// </summary>
        public int mode = 0;

        public string employeeID;

        public string employeeName;

        public string employeeRole;

        public FormMain() {
            InitializeComponent();
        }

        public void LoggedInState(int mode) {
            switch (mode) {
                case 1:
                    masterToolStripMenuItem.Visible = true;
                    transactionToolStripMenuItem.Visible = true;
                    loginToolStripMenuItem.Visible = false;
                    logoutToolStripMenuItem.Visible = true;
                    break;

                case 2:
                    masterToolStripMenuItem.Visible = true;
                    masterEmployeeToolStripMenuItem.Visible = false;
                    transactionToolStripMenuItem.Visible = true;
                    loginToolStripMenuItem.Visible = false;
                    logoutToolStripMenuItem.Visible = true;
                    break;

                default:
                    break;
            }
        }



        public void InitialState() {
            masterToolStripMenuItem.Visible = false;
            transactionToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = false;
            toolStripStatusLabelWelcome.Text = "Welcome Guest, Please Login to get full services";
            mode = 0;
        }

        private void timer_Tick(object sender, EventArgs e) {
            toolStripStatusLabelDate.Text = String.Format("Date: {0:dd MMMM yyyy}", DateTime.Now);
            toolStripStatusLabelTime.Text = String.Format("Time: {0:HH:mm:ss}", DateTime.Now);
            //StandbyMode(flag);
        }

        public void Form1_Load(object sender, EventArgs e) {
            timer.Start();
            InitialState();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e) {
            FormLogin login = new FormLogin();
            //login.MdiParent = this;
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK) {
                if (login.mode == 1) {
                    LoggedInState(1);
                } else {
                    LoggedInState(2);
                }
                employeeID = login.employeeID;
                employeeName = login.employeeName;
                employeeRole = login.employeeRole;
                toolStripStatusLabelWelcome.Text = String.Format("Username: {0}             Role: {1}", employeeName, employeeRole);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            employeeName = string.Empty;
            InitialState();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
            Dispose();
        }

        internal void Form1_Load() {
            throw new NotImplementedException();
        }

        private void buyBookToolStripMenuItem_Click(object sender, EventArgs e) {
            FormBuyBook bb = new FormBuyBook();
            bb.MdiParent = this;
            bb.Show();
        }

        private void viewTransactionToolStripMenuItem_Click(object sender, EventArgs e) {
            FormViewTransaction vt = new FormViewTransaction();
            vt.MdiParent = this;
            vt.Show();
        }

        private void masterEmployeeToolStripMenuItem_Click(object sender, EventArgs e) {
            FormMasterEmployee me = new FormMasterEmployee();
            me.MdiParent = this;
            me.Show();
        }

        private void masterBookTypeToolStripMenuItem_Click(object sender, EventArgs e) {
            FormMasterBookType mbt = new FormMasterBookType();
            mbt.MdiParent = this;
            mbt.Show();
        }

        private void masterBookToolStripMenuItem_Click(object sender, EventArgs e) {
            FormMasterBook mb = new FormMasterBook();
            mb.MdiParent = this;
            mb.Show();
        }
    }
}
