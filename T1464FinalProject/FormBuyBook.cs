using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T1464FinalProject {
    public partial class FormBuyBook : Form {
        // TODO: a lot.

        FormMain main = new FormMain();

        public string employeeID;

        DatabaseConnect con;

        public FormBuyBook() {
            con = new DatabaseConnect();
            InitializeComponent();
        }

        private void FormBuyBook_Load(object sender, EventArgs e) {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {
            lblTime.Text = string.Format("Date/Time:     {0:dd MMMM yyyy, HH:mm:ss}", DateTime.Now);
        }
    }
}
