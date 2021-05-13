using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeShopManagement.Database;
using System.Data.SqlClient;

namespace CafeShopManagement
{
    public partial class Form1 : Form
    {
        DBOperations dbOperation = new DBOperations();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginVerified = dbOperation.VerifyLoginDetails(txtUsername.Text, txtPassword.Text);

            if (loginVerified)
            {
                this.Hide();
                new Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Invalid login details!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard ds = new Dashboard("Guest");
            ds.Show();
            this.Hide();
        }
    }
}
