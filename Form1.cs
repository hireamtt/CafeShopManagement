using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=DESKTOP-D7D5MT3;Initial Catalog=testdbase;User ID=sa;Password=ramya@123";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("connection succeded");
            SqlCommand command = new SqlCommand();
          
            command.Connection = cnn;
            command.CommandText = "select* from admin where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
           //SqlDataReader datareader= command.ExecuteReader();
            /*while(datareader.Read())
            {

                Output = Output + datareader.GetValue(0) + "-" + datareader.GetValue(1) + "\n";

            }
            */


            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                new Dashboard().Show();
                
                
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
           
            cnn.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
