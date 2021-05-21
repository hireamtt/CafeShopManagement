using CafeShopManagement.Database;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CafeShopManagement.AllUserControls
{
    public partial class UC_PlaceOrder : UserControl
    {
        DBOperations dbop = new DBOperations();
        String query;

        private static UC_PlaceOrder _instance;

        public static UC_PlaceOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_PlaceOrder();
                return _instance;
            }
        }
        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String category = comboCategory.Text;
            query = "select name from items where category='" + category + "'";
            showItemList(query);

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "select name from items where category='" + category + "' and name like '" +textSearch.Text+"%'";
            showItemList(query);
        }
        private void showItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = dbop.GetData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.ResetText();
            textTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            textItemName.Text = text;
            query = "select price from items where name='" + text + "'";
            DataSet ds = dbop.GetData(query);

            try
            {
                textPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)

            {
                throw;
            }
            
            
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 qua = Int64.Parse(txtQuantity.Value.ToString());
            Int64 price = Int64.Parse(textPrice.Text);
            textTotal.Text = (qua * price).ToString();
        }

        protected int n, total = 0;

        

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "0" && textTotal.Text != "")
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textItemName.Text;
                dataGridView1.Rows[n].Cells[1].Value = textPrice.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtQuantity.Value;
                dataGridView1.Rows[n].Cells[3].Value = textTotal.Text;

                total += int.Parse(textTotal.Text);
                labelTotalAmount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimum quantity should be one", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int amt;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amt = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                throw;
            }
            total -= amt;
            labelTotalAmount.Text = "Rs. " + total;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Deatiled Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total payable amount : " + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            labelTotalAmount.Text = "Rs. " + total;

        }

       
    }
}
