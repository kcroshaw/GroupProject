using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// Connection string to the database.
        /// </summary>
        private string sConnectionString;
        public clsSearchLogic()
        {
            sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb";
        }

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
        /// Returns a DataView of all invoices
        /// </summary>
        /// <returns></returns>
        public DataView GetInvoices()
        {
            try
            {
                clsSearchSQL searchSQL = new clsSearchSQL();
                string query = searchSQL.SelectAllInvoices();
                int retVal = 0;

                return new DataView(ExecuteSQLStatement(query, ref retVal).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a List of all values from a specified column
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public List<string> GetLists(string column)
        {
            try
            {
                clsSearchSQL searchSQL = new clsSearchSQL();
                string query = searchSQL.SelectColumn(column);
                int retVal = 0;

                DataView results = new DataView(ExecuteSQLStatement(query, ref retVal).Tables[0]);
                List<string> list = new List<string>();
                foreach (DataRow row in results.Table.Rows)
                {
                    list.Add(row.ItemArray[0].ToString());
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a DataView of all invoices that match specified values
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="column2"></param>
        /// <param name="value2"></param>
        /// <param name="column3"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        public DataView GetInvoicesWhere(string column, string value, string column2 , string value2, string column3, string value3)
        {
            try
            {
                clsSearchSQL searchSQL = new clsSearchSQL();
                string query = searchSQL.SelectInvoicesWhere(column, value, column2, value2, column3, value3);
                int retVal = 0;

                return new DataView(ExecuteSQLStatement(query, ref retVal).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
