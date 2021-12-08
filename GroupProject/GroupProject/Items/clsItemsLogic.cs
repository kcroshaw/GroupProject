using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    class clsItemsLogic
    {
        clsItemsSQL clsItemsSQL = new clsItemsSQL();

        public DataSet GetItems()
        {
            try
            {
                DataSet ds = new DataSet();
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb"))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(clsItemsSQL.SelectItems(), conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void AddItem(string itemCode, string itemDesc, int itemCost)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb"))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(clsItemsSQL.InsertItem(itemCode, itemDesc, itemCost), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void UpdateItem(string itemDesc, int itemCost, string itemCode)
        {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb"))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(clsItemsSQL.UpdateItems(itemDesc, itemCost, itemCode), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataSet IsItemOnInvoice(string itemCode)
        {
            try
            {
                DataSet ds = new DataSet();
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb"))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(clsItemsSQL.SelectItemInvoice(itemCode), conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void DeleteItem(string itemCode)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb"))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(clsItemsSQL.DeleteItem(itemCode), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
