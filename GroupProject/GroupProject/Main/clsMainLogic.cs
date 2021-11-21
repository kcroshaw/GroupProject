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
        /// returns a data set that contains the data returned from the database based on the passed in sql statement
        /// </summary>
        /// <param name="sSQL">sql statement that is going to be executed</param>
        /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
		public DataSet ExecuteSQLStatement(string sSQL)
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
                //return the DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}