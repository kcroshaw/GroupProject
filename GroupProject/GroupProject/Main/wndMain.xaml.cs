using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// allows the user to search for an invoice
        /// </summary>
        Search.wndSearch WndSearch;

        /// <summary>
        /// allows the user to edit an item
        /// </summary>
        Items.wndItems WndItem;

        /// <summary>
        /// holds all the business logic for the main window
        /// </summary>
        clsMainLogic ClsMainLogic;

        /// <summary>
        /// invoice ID that will be passed between windows
        /// </summary>
        public int currInvoiceID;

        /// <summary>
        /// constructor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            ClsMainLogic = new clsMainLogic();


            // initially populate combo boxes

            List<int> imyList = new List<int>(); // create temp lists
            List<string> smyList = new List<string>();
            
            imyList = ClsMainLogic.populateInvoices(); // populate invoices combo box
            comboInvoice.ItemsSource = imyList;
            
            smyList = ClsMainLogic.populateItems(); // populate items combo box
            comboAddItems.ItemsSource = smyList;
        }

        #region Menu Controls

        /// <summary>
        /// opens the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchForInvoice(object sender, RoutedEventArgs e)
        {
            try
            {
                WndSearch = new Search.wndSearch();

                if (WndSearch.ShowDialog() == true)
                {
                    currInvoiceID = WndSearch.currInvoiceID; // get the searched invoice id
                    int index = -1;
                    foreach (int item in comboInvoice.Items) // iterate through until we find an invoice id that matches
                    {
                        index++; // increase index so we know what to change
                        if (item == currInvoiceID)
                        {
                            break;
                        }
                    }
                    comboInvoice.SelectedIndex = index; // update selected index to be our index we incremented
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// opens the item window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateItem(object sender, RoutedEventArgs e)
        {
            try
            {
                WndItem = new Items.wndItems();
                // this is how we are going to pass data between windows
                WndItem.currInvoiceID = currInvoiceID;
                WndItem.ShowDialog();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Selection Changes

        /// <summary>
        /// updates the comboinvoiceitems every time a new invoice is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int selection; // grab the current invoice
                Int32.TryParse(comboInvoice.SelectedItem.ToString(), out selection);

                List<string> myList = new List<string>(); // refresh combo invoice items
                myList = ClsMainLogic.populateInvoiceItems(selection);
                comboInvoiceItems.ItemsSource = myList;

                dvInvoice.ItemsSource = ClsMainLogic.populateDataGrid(selection); // refresh the data grid
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// changes the item price text box each time an item is selected from the combo for add items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboAddItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string itemName = comboAddItems.SelectedItem.ToString(); // get item name
                string price = ClsMainLogic.getItemPrice(itemName); // get item price
                itemPrice.Text = price; // update text box to display price
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Invoice Controls

        /// <summary>
        /// saves the current invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // code goes here
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// creates a new invoice in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // code goes here
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// deletes the current selected invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selection; // get current invoice
                Int32.TryParse(comboInvoice.SelectedItem.ToString(), out selection);

                ClsMainLogic.deleteInvoice(selection);

                comboInvoice.SelectedItem = null; // select nothing in invoice combo
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Item Controls

        /// <summary>
        /// deletes the current selected item from the current selected invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selection;
                Int32.TryParse(comboInvoice.SelectedItem.ToString(), out selection);

                string selectedItem = comboInvoiceItems.SelectedItem.ToString();

                ClsMainLogic.deleteItemFromInvoice(selection, selectedItem);

                comboInvoiceItems.SelectedItem = null; // select nothing
                dvInvoice.ItemsSource = ClsMainLogic.populateDataGrid(selection); // refresh data grid
                List<string> myList = new List<string>(); // refresh combo invoice items
                myList = ClsMainLogic.populateInvoiceItems(selection);
                comboInvoiceItems.ItemsSource = myList;

            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// adds the currently selected item from comboAddItems to the current selected invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selection; // get current invoice id
                Int32.TryParse(comboInvoice.SelectedItem.ToString(), out selection);

                string selectedItem = comboAddItems.SelectedItem.ToString(); // get currently selected item

                ClsMainLogic.addItemToInvoice(selection, selectedItem);

                dvInvoice.ItemsSource = ClsMainLogic.populateDataGrid(selection); // refresh data grid
                List<string> myList = new List<string>(); // refresh combo invoice items
                myList = ClsMainLogic.populateInvoiceItems(selection);
                comboInvoiceItems.ItemsSource = myList;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }
}
