using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

namespace GroupProject.Items
{
    class clsItemsSQL
    {

        public clsItemsSQL()
        {
        }

        /// <summary>
        /// SQL gets all data for an item
        /// </summary>
        /// <returns>All of the items in the database</returns>
        public string SelectItems()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            return sSQL;
        }

        /// <summary>
        /// Selects the invoice for a given item code
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns>Invoice number for given item code</returns>
        public string SelectItemInvoice(string itemCode)
        {
            string sSQL = "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// SQL updates a specific item in the database
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="itemCost"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string UpdateItems(string itemDesc, int itemCost, string itemCode)
        {
            string sSQL = "UPDATE ItemDesc Set ItemDesc = '" + itemDesc + "', " + "Cost = " + itemCost + " WHERE ItemCode = '" + itemCode + "'";
            return sSQL;
        }

        /// <summary>
        /// SQL inserts a new item into the database
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="itemCost"></param>
        /// <returns></returns>
        public string InsertItem(string itemCode, string itemDesc, int itemCost)
        {
            string sSQL = "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" + itemCode + "', '" + itemDesc + "', " + itemCost + ")";
            return sSQL;
        }

        /// <summary>
        /// Deletes a specific item from the database
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string DeleteItem(string itemCode)
        {
            string sSQL = "DELETE FROM ItemDesc Where ItemCode = '" + itemCode + "'";
            return sSQL;
        }
    }
}
