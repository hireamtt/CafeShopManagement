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
    public partial class UC_UpdateItems : UserControl

    {
        DBOperations dbops = new DBOperations();
        String query;

        private static UC_UpdateItems _instance;

        public static UC_UpdateItems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_UpdateItems();
                return _instance;
            }
        }
        public UC_UpdateItems()
        {
            InitializeComponent();
        }

        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            query = "select* from items";
            loadData(query);
        }
        public void loadData(String qur)
        {
            query = qur;
            //query = "select* from items";
            DataSet ds = dbops.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "select* from items where name like '" + textSearchItem.Text + "%'";
            loadData(query);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
