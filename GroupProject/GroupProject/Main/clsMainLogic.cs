using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainLogic
    {
        /// <summary>
        /// class used to get all sql statements
        /// </summary>
        clsMainSQL ClsMainSQL;

        /// <summary>
        /// connection string to the database
        /// </summary>
        private string sConnectionString;

        /// <summary>
        /// constructor that sets connection string and starts any objects
        /// </summary>
        public clsMainLogic()
        {
            sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb";

            ClsMainSQL = new clsMainSQL();
        }

        /// <summary>
        /// populates the invoices combo box with all invoice numbers from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<int> populateInvoices()
        {
            try
            {
                List<int> myList = new List<int>();
                string sql = ClsMainSQL.selectAllInvoices();
                int iRet = 0;
                DataSet ds = new DataSet();
                ds = ExecuteSQLStatement(sql, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    int temp;
                    Int32.TryParse(ds.Tables[0].Rows[i][0].ToString(), out temp);
                    myList.Add(temp);
                }

                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// populates the items combo box with all item names from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> populateItems()
        {
            try
            {
                List<string> myList = new List<string>();
                string sql = ClsMainSQL.selectAllItems();
                int iRet = 0;
                DataSet ds = new DataSet();
                ds = ExecuteSQLStatement(sql, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    string temp = ds.Tables[0].Rows[i][1].ToString();
                    myList.Add(temp);
                }

                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// populates the invoice items combo box with all item names from the specific invoice
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> populateInvoiceItems(int invoiceid)
        {
            try
            {
                List<string> myList = new List<string>();
                string sql = ClsMainSQL.selectAllItemsFromInvoice(invoiceid);
                int iRet = 0;
                DataSet ds = new DataSet();
                ds = ExecuteSQLStatement(sql, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    string temp = ds.Tables[0].Rows[i][1].ToString();
                    myList.Add(temp);
                }

                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a data view of all the items given an invoice
        /// </summary>
        /// <param name="invoiceid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataView populateDataGrid(int invoiceid)
        {
            try
            {
                string sql = ClsMainSQL.selectAllItemsFromInvoice(invoiceid);
                int iRet = 0;
                
                return new DataView(ExecuteSQLStatement(sql, ref iRet).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// deletes the currently selected invoice
        /// </summary>
        /// <param name="invoiceid"></param>
        /// <exception cref="Exception"></exception>
        public void deleteInvoice(int invoiceid)
        {
            try
            {
                string sinvoiceid = invoiceid.ToString(); // quick convert
                string sql = ClsMainSQL.deleteAllItemsFromInvoice(sinvoiceid);
                ExecuteNonQuery(sql);
                sql = ClsMainSQL.deleteInvoice(sinvoiceid);
                ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// adds the selected item to the current invoice
        /// </summary>
        /// <param name="invoiceid"></param>
        /// <param name="itemName"></param>
        /// <exception cref="Exception"></exception>
        public void addItemToInvoice(int invoiceid, string itemName)
        {
            try
            {
                string sinvoiceid = invoiceid.ToString(); // quick convert

                string sSQL = ClsMainSQL.getItemCode(itemName);
                string itemCode = ExecuteScalarSQL(sSQL);

                sSQL = ClsMainSQL.getLineItemNum(sinvoiceid);
                string maxLineNum = ExecuteScalarSQL(sSQL);

                sSQL = ClsMainSQL.insertLineItem(sinvoiceid, maxLineNum, itemCode);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns the items price given its name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string getItemPrice(string itemName)
        {
            try
            {
                string sSQL = ClsMainSQL.getItemPrice(itemName);
                string price = ExecuteScalarSQL(sSQL).ToString();
                return price;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// deletes an item from an invoice given its name
        /// </summary>
        /// <param name="invoiceid"></param>
        /// <param name="itemName"></param>
        /// <exception cref="Exception"></exception>
        public void deleteItemFromInvoice(int invoiceid, string itemName)
        {
            try
            {
                string SQL = ClsMainSQL.getItemCode(itemName);
                string itemCode = ExecuteScalarSQL(SQL).ToString();
                SQL = ClsMainSQL.deleteItem(invoiceid.ToString(), itemCode);
                ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }










        #region SQLexecutes

        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting values
        /// are returned in a DataSet.  The number of rows returned from the query will be put into
        /// the reference parameter iRetVal.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <param name="iRetVal">Reference parameter that returns the number of selected rows.</param>
        /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
		public DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                //Create a new DataSet
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }

                //Set the number of values returned
                iRetVal = ds.Tables[0].Rows.Count;

                //return the DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting single 
        /// value is returned.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns a string from the scalar SQL statement.</returns>
		public string ExecuteScalarSQL(string sSQL)
        {
            try
            {
                //Holds the return value
                object obj;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Execute the scalar SQL statement
                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                //See if the object is null
                if (obj == null)
                {
                    //Return a blank
                    return "";
                }
                else
                {
                    //Return the value
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statment that is a non query and executes it.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns the number of rows affected by the SQL statement.</returns>
		public int ExecuteNonQuery(string sSQL)
        {
            try
            {
                //Number of rows affected
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    //Execute the non query SQL statement
                    iNumRows = cmd.ExecuteNonQuery();
                }

                //return the number of rows affected
                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion
    }
}