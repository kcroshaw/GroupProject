using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    class clsSearchSQL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public clsSearchSQL()
        {

        }

        /// <summary>
        /// SQL script to return all Invoices
        /// </summary>
        /// <returns></returns>
        public string SelectAllInvoices()
        {
            return "SELECT InvoiceNum, InvoiceDate, TotalCost " +
                   "FROM Invoices ORDER BY InvoiceNum";
        }

        /// <summary>
        /// SQL script to return all invoices that match selected values
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="column2"></param>
        /// <param name="value2"></param>
        /// <param name="column3"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        public string SelectInvoicesWhere(string column, string value, string column2, string value2, string column3, string value3)
        {
            //TODO: InvoiceDate value in query throwing exception

            if (column == "InvoiceDate")
            {
                value = $"#{value}#";
            }
            string query = "SELECT InvoiceNum, InvoiceDate, TotalCost " +
                           "FROM Invoices " +
                           $"WHERE {column} = {value}";

            if (value2 != null)
            {
                if (column2 == "InvoiceDate")
                {
                    value2 = $"#{value2}#";
                }
                query += $"AND {column2} = {value2}";
            }

            if (value3 != null)
            {
                if (column3 == "InvoiceDate")
                {
                    value3 = $"#{value3}#";
                }
                query += $"AND {column3} = {value3}";
            }

            return query;
        }

        /// <summary>
        /// SQL script to return all distinct values from a column
        /// </summary>
        /// <param name="column"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public string SelectColumn(string column, string order = "ASC")
        {
            return $"SELECT DISTINCT {column} FROM Invoices ORDER BY {column} {order}";
        }
    }
}
