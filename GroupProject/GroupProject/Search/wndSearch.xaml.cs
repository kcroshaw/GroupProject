using System;
using System.Collections.Generic;
using System.Data;
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

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// invoice ID that will be passed between windows
        /// </summary>
        public int CurrInvoiceID { get; set; }
        public wndSearch()
        {
            try { 
                InitializeComponent();

                clsSearchLogic searchLogic = new clsSearchLogic();
                Invoices_DataGrid.ItemsSource = searchLogic.GetInvoices();
                Invoice_Number_ComboBox.ItemsSource = searchLogic.GetLists("InvoiceNum");
                Invoice_Date_ComboBox.ItemsSource = searchLogic.GetLists("InvoiceDate");
                Invoice_Charge_ComboBox.ItemsSource = searchLogic.GetLists("TotalCost");
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Sends the currently selected invoice to main window
        /// Closes the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Invoice(object sender, RoutedEventArgs e)
        {
            DataRowView invoice = Invoices_DataGrid.SelectedItem as DataRowView;
            CurrInvoiceID = int.Parse(invoice.Row.ItemArray[0].ToString());
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Updates the DataGrid with new result set when an option is
        /// selected from the Invoice Number dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Number_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
                if (Invoice_Number_ComboBox.SelectedIndex > -1)
                {
                    clsSearchLogic searchLogic = new clsSearchLogic();
                    Invoices_DataGrid.ItemsSource = searchLogic.GetInvoicesWhere(
                                                    "InvoiceNum", Invoice_Number_ComboBox.SelectedIndex > -1 ? Invoice_Number_ComboBox.SelectedValue.ToString() : null,
                                                    "InvoiceDate", Invoice_Date_ComboBox.SelectedIndex > -1 ? Invoice_Date_ComboBox.SelectedValue.ToString() : null,
                                                    "TotalCost", Invoice_Charge_ComboBox.SelectedIndex > -1 ? Invoice_Charge_ComboBox.SelectedValue.ToString() : null);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Updates the DataGrid with new result set when an option is
        /// selected from the Invoice Date dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Date_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            { 
                if (Invoice_Date_ComboBox.SelectedIndex > -1)
                {
                    clsSearchLogic searchLogic = new clsSearchLogic();
                    Invoices_DataGrid.ItemsSource = searchLogic.GetInvoicesWhere(
                                                    "InvoiceDate", Invoice_Date_ComboBox.SelectedIndex > -1 ? Invoice_Date_ComboBox.SelectedValue.ToString() : null,
                                                    "InvoiceNum", Invoice_Number_ComboBox.SelectedIndex > -1 ? Invoice_Number_ComboBox.SelectedValue.ToString() : null,
                                                    "TotalCost", Invoice_Charge_ComboBox.SelectedIndex > -1 ? Invoice_Charge_ComboBox.SelectedValue.ToString() : null);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the DataGrid with new result set when an option is
        /// selected from the Invoice Charge dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Charge_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Invoice_Charge_ComboBox.SelectedIndex > -1)
                {
                    clsSearchLogic searchLogic = new clsSearchLogic();
                    Invoices_DataGrid.ItemsSource = searchLogic.GetInvoicesWhere(
                                                    "TotalCost", Invoice_Charge_ComboBox.SelectedIndex > -1 ? Invoice_Charge_ComboBox.SelectedValue.ToString() : null,
                                                    "InvoiceNum", Invoice_Number_ComboBox.SelectedIndex > -1 ? Invoice_Number_ComboBox.SelectedValue.ToString() : null,
                                                    "InvoiceDate", Invoice_Date_ComboBox.SelectedIndex > -1 ? Invoice_Date_ComboBox.SelectedValue.ToString() : null);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
    }
}

        /// <summary>
        /// Resets the values in the dropdown menus when "Clear Search" is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Search_Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                Invoice_Number_ComboBox.SelectedIndex = -1;
                Invoice_Date_ComboBox.SelectedIndex = -1;
                Invoice_Charge_ComboBox.SelectedIndex = -1;
                clsSearchLogic searchLogic = new clsSearchLogic();
                Invoices_DataGrid.ItemsSource = searchLogic.GetInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Allows the user to cllck "Select Invoice" after one is selected from DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoices_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Invoices_DataGrid.SelectedIndex > -1)
                {
                    Select_Invoice_Button.IsEnabled = true;
                }
                else
                {
                    Select_Invoice_Button.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles error messaging
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
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
