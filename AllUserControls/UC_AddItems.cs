using CafeShopManagement.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CafeShopManagement.AllUserControls
{
    public partial class UC_AddItems : UserControl
    {
        DBOperations dbo = new DBOperations();
        String query;

        private static UC_AddItems _instance;

        public static UC_AddItems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_AddItems();
                return _instance;
            }
        }
        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void UC_AddItems_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "insert into items (name,category,price) values ('" + txtItemName.Text + "','" + txtCategory.Text + "'," + txtPrice.Text + ")";
            dbo.setData(query);
            clearAll();
        }
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }

        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
