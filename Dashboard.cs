using CafeShopManagement.AllUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CafeShopManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(String user)
        {
            InitializeComponent();

            if(user=="Guest")
            {
                btnAddItem.Hide();
                btnUpdateItem.Hide();
                btnRemoveItem.Hide();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (!panel2.Controls.Contains(UC_PlaceOrder.Instance))
            {
                panel2.Controls.Add(UC_PlaceOrder.Instance);
                UC_PlaceOrder.Instance.Dock = DockStyle.Fill;
                UC_PlaceOrder.Instance.BringToFront();
            }
            else
                UC_PlaceOrder.Instance.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(UC_AddItems.Instance))
            {
                panel2.Controls.Add(UC_AddItems.Instance);
                UC_AddItems.Instance.Dock = DockStyle.Fill;
                UC_AddItems.Instance.BringToFront();
            }
            else
                UC_AddItems.Instance.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(UC_UpdateItems.Instance))
            {
                panel2.Controls.Add(UC_UpdateItems.Instance);
                UC_UpdateItems.Instance.Dock = DockStyle.Fill;
                UC_UpdateItems.Instance.BringToFront();
            }
            else
                UC_UpdateItems.Instance.BringToFront();

        }
    }
}
