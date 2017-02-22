using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectProgbis
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void masterToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.Date.ToLongDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel7.Text = DateTime.Now.ToLongTimeString();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 login = new Form2();
            login.MdiParent = this;
            login.Show();
        }

     

       
    }
}
