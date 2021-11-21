using System;
using System.Collections.Generic;
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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ResetItems();
            btnConfirmAdd.Visibility = Visibility.Visible;
            EnableItems();
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            ResetItems();
            btnConfirmEdit.Visibility = Visibility.Visible;
            EnableItems();
        }
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            ResetItems();
            btnConfirmDelete.Visibility = Visibility.Visible;
            EnableItems();
        }

        private void btnConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            string itemCode = tbxItemCode.Text;
            string itemDesc = tbxItemDesc.Text;
            int itemCost = Convert.ToInt32(tbxItemCost.Text);
            clsItemsLogic.AddItem(itemCode, itemDesc, itemCost);
            dgItems.ItemsSource = clsItemsLogic.GetItems().Tables[0].DefaultView;
            ResetItems();
        }
        private void btnConfirmEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirmDelete_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
