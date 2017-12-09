using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace admin
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mForm = new mainForm();
            this.Hide();
            mForm.ShowDialog();
            this.Close();
            this.Dispose();
            
        }
    }
}
