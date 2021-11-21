using GroupProject.Items;
using GroupProject.Main;
using GroupProject.Search;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wndItems WndItems = new wndItems();
        wndSearch WndSearch = new wndSearch();
        wndMain WndMain = new wndMain();
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WndItems.ShowDialog();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            WndSearch.ShowDialog();
            Show();
        }

        private void main_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            WndMain.ShowDialog();
            Show();
        }
    }
}
