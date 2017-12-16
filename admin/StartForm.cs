using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace admin
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clearance mForm = new Clearance();
            mForm.ShowDialog();
        }
    }
}
