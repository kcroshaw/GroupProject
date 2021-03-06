using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainSQL
    {
        /* SQL statements given in document
        - UPDATE Invoices SET TotalCost = 1200 WHERE InvoiceNum = 123
        - DELETE From LineItems WHERE InvoiceNum = 1234
        - DELETE From Invoices WHERE InvoiceNum = 1234
        - INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(123, 1, 'AA')
        - INSERT INTO Invoices(InvoiceDate, TotalCost) Values('#4/13/2018#', 100)
        - SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 123
        - select ItemCode, ItemDesc, Cost from ItemDesc
        - SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = 5000
        */

        




        /// <summary>
        /// selects all rows from Invoices table
        /// </summary>
        /// <returns>all invoices</returns>
        public string selectAllInvoices()
        {
            try
            {
                string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// selects all rows from ItemsDesc table
        /// </summary>
        /// <returns>all items</returns>
        public string selectAllItems()
        {
            try
            {
                string sSQL = "select ItemCode, ItemDesc, Cost from ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns all items from LineItems given a specific invoice ID
        /// </summary>
        /// <param name="iInvoiceID">id to get items from</param>
        /// <returns>all items from LineItems based on sInvoiceID</returns>
        public string selectAllItemsFromInvoice(int iInvoiceID)
        {
            try
            {
                string sSQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + iInvoiceID.ToString();
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a specific item's info from ItemsDesc
        /// </summary>
        /// <param name="sItemID">specific item's ID</param>
        /// <returns>items info</returns>
        public string selectItem(string sItemID)
        {
            try
            {
                string sSQL = "select ItemCode, ItemDesc, Cost from ItemDesc WHERE ItemCode = " + sItemID;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// inserts a new invoice given a date and a cost
        /// </summary>
        /// <param name="sDate">data for the invoice</param>
        /// <param name="sCost">total cost for the invoice</param>
        /// <returns>SQL statement for adding a new invoice</returns>
        public string addInvoice(string sDate, string sCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values('#" + sDate + "#', " + sCost + ")";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// first part of deleting an invoice, deletes invoice from invoices based on invoice num
        /// </summary>
        /// <param name="sInvoiceNum">invoice to be deleted</param>
        /// <returns>SQL statement to be executed</returns>
        public string deleteInvoice(string sInvoiceNum)
        {
            try
            {
                string sSQL = "DELETE From Invoices WHERE InvoiceNum = " + sInvoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// 2nd part of deleting an invoice. deletes all line items based on invoice number
        /// </summary>
        /// <param name="sInvoiceNum">invoice to be deleted</param>
        /// <returns>SQL statement to be executed</returns>
        public string deleteAllItemsFromInvoice(string sInvoiceNum)
        {
            try
            {
                string sSQL = "DELETE From LineItems WHERE InvoiceNum = " + sInvoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// inserts a line item given the invoice, line item number, and item code
        /// </summary>
        /// <param name="sInvoiceNum">invoice to be updated</param>
        /// <param name="sLineItemNum">next line item number</param>
        /// <param name="sItemCode">item to be put in</param>
        /// <returns>SQL statement to be executed</returns>
        public string insertLineItem(string sInvoiceNum, string sLineItemNum, string sItemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(" + sInvoiceNum + ", " + sLineItemNum + ", '" + sItemCode + "')";
                return sSQL;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}