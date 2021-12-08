using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        clsItemsLogic clsItemsLogic;
        bool bEdit;
        bool bDelete;
        bool bAdd;

        /// <summary>
        /// invoice ID that will be passed between windows
        /// </summary>
        public int currInvoiceID;
        public wndItems()
        {
            InitializeComponent();
            clsItemsLogic = new clsItemsLogic();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgItems.ItemsSource = clsItemsLogic.GetItems().Tables[0].DefaultView;
        }

        /// <summary>
        /// Method to populate the appropriate buttons and fields needed to add item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            bAdd = true;
            bEdit = false;
            bDelete = false;
            ResetItems();
            btnConfirmAdd.Visibility = Visibility.Visible;
            EnableItems();
        }

        /// <summary>
        /// Method to populate the appropriate buttons and fields needed to edit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            bAdd = false;
            bEdit = true;
            bDelete = false;
            ResetItems();
            btnConfirmEdit.Visibility = Visibility.Visible;
            EnableItems();
            tbxItemDesc.IsEnabled = true;
            tbxItemCost.IsEnabled = true;
            tbxItemCode.IsEnabled = false;
            GetSelectedItem();
        }

        /// <summary>
        /// Method to populate the appropriate buttons and fields needed to delete item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            bAdd = false;
            bEdit = false;
            bDelete = true;
            ResetItems();
            btnConfirmDelete.Visibility = Visibility.Visible;
            DisableItems();
            if (dgItems.SelectedItems != null)
            {
                GetSelectedItem();
            }
        }

        /// <summary>
        /// Method to confirm that addition of item into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            string itemCode = tbxItemCode.Text;
            string itemDesc = tbxItemDesc.Text;
            int itemCost = Convert.ToInt32(tbxItemCost.Text);
            clsItemsLogic.AddItem(itemCode, itemDesc, itemCost);
            dgItems.ItemsSource = clsItemsLogic.GetItems().Tables[0].DefaultView;
            ResetItems();
        }

        /// <summary>
        /// Method to confirm that edit of item in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            if (bEdit == true)
            {
                if (tbxItemCost.Text != "" && tbxItemDesc.Text != "")
                {
                    clsItemsLogic.UpdateItem(tbxItemDesc.Text, Convert.ToInt32(tbxItemCost.Text), tbxItemCode.Text);
                    bEdit = false;
                    dgItems.ItemsSource = clsItemsLogic.GetItems().Tables[0].DefaultView;
                }
            }
        }

        /// <summary>
        /// Method to confirm that deletion of item from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmDelete_Click(object sender, RoutedEventArgs e)
        {
            string itemCode = tbxItemCode.Text;
            int invoices = clsItemsLogic.IsItemOnInvoice(itemCode).Tables[0].Rows.Count;
            if (invoices > 0)
            {
                MessageBox.Show("Can't delete item since it is included on an invoice");
            }
            else
            {
                clsItemsLogic.DeleteItem(itemCode);
                bDelete = false;
                MessageBox.Show("Item Deleted!");
                dgItems.ItemsSource = clsItemsLogic.GetItems().Tables[0].DefaultView;
            }
        }

        /// <summary>
        /// Method to enable the text boxes once the option has been clicked.
        /// </summary>
        private void EnableItems()
        {
            tbxItemCode.Visibility = Visibility.Visible;
            tbxItemCode.Text = "";
            tbxItemDesc.Visibility = Visibility.Visible;
            tbxItemDesc.Text = "";
            tbxItemCost.Visibility = Visibility.Visible;
            tbxItemCost.Text = "";
        }

        private void DisableItems()
        {
            tbxItemCode.Visibility = Visibility.Visible;
            tbxItemCode.IsEnabled = false;
            tbxItemCode.Text = "";
            tbxItemDesc.Visibility = Visibility.Visible;
            tbxItemDesc.IsEnabled = false;
            tbxItemDesc.Text = "";
            tbxItemCost.Visibility = Visibility.Visible;
            tbxItemCost.IsEnabled = false;
            tbxItemCost.Text = "";
        }

        /// <summary>
        /// Method to hide the text boxes and buttons once the option has been clicked and set the text back to blank.
        /// </summary>
        private void ResetItems()
        {
            tbxItemCode.Visibility = Visibility.Hidden;
            tbxItemCode.Text = "";
            tbxItemDesc.Visibility = Visibility.Hidden;
            tbxItemDesc.Text = "";
            tbxItemCost.Visibility = Visibility.Hidden;
            tbxItemCost.Text = "";
            btnConfirmAdd.Visibility = Visibility.Hidden;
            btnConfirmEdit.Visibility = Visibility.Hidden;
            btnConfirmDelete.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Checks to see if the selected item in the datagrid changed and updates the text fields accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bEdit == true || bDelete == true)
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string itemCode = ((TextBlock)RowColumn.Content).Text;
                tbxItemCode.Text = itemCode;
                RowColumn = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
                string itemDesc = ((TextBlock)RowColumn.Content).Text;
                tbxItemDesc.Text = itemDesc;
                RowColumn = dataGrid.Columns[2].GetCellContent(row).Parent as DataGridCell;
                string itemCost = ((TextBlock)RowColumn.Content).Text;
                tbxItemCost.Text = itemCost;
            }
        }


        private void GetSelectedItem()
        {
            DataGridRow row = (DataGridRow)dgItems.ItemContainerGenerator.ContainerFromIndex(dgItems.SelectedIndex);
            DataGridCell RowColumn = dgItems.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string itemCode = ((TextBlock)RowColumn.Content).Text;
            tbxItemCode.Text = itemCode;
            RowColumn = dgItems.Columns[1].GetCellContent(row).Parent as DataGridCell;
            string itemDesc = ((TextBlock)RowColumn.Content).Text;
            tbxItemDesc.Text = itemDesc;
            RowColumn = dgItems.Columns[2].GetCellContent(row).Parent as DataGridCell;
            string itemCost = ((TextBlock)RowColumn.Content).Text;
            tbxItemCost.Text = itemCost;
        }
    }
}
