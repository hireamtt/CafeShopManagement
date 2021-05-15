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
    }
}
