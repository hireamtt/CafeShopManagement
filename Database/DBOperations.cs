using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CafeShopManagement.Database
{
    class DBOperations
    {
        SqlConnection dbCon = new SqlConnection();
        SqlCommand cmdStr = new SqlCommand();
        SqlDataAdapter cmdRes = new SqlDataAdapter();

        private bool DBConnection()
        {
            try
            {
                dbCon = new SqlConnection(@"Data Source=UTS-RAMYASHREE;Initial Catalog=testdbase;User ID=sa;Password=gts@123");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerifyLoginDetails(string userName, string password)
        {
            if (DBConnection())
            {
                DataTable loginDetails = new DataTable();

                try
                {
                    dbCon.Open();

                    cmdStr.Connection = dbCon;
                    cmdStr.CommandText = "select* from admin where Username='" + userName + "' and Password='" + password + "'";

                    cmdRes = new SqlDataAdapter(cmdStr);
                    cmdRes.Fill(loginDetails);

                    dbCon.Close();
                }
                catch (Exception)
                {
                    throw;
                }

                if (loginDetails.Rows.Count == 1)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
