using BloodBankInventory.BLL;
using BloodBankInventory.Exceptions;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BloodBankInventory.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodInventoryBLL pb = new BloodInventoryBLL();
                DataTable dt = pb.BloodInventoryDisplay();
                if (dt != null)
                {
                    dataGrid.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Table is empty", "Blood Inventory Management System");
                }
            }
            catch (BloodInventoryException ex)
            {
                MessageBox.Show(ex.Message, "Blood Inventory Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Blood Inventory Management System");
            }
        }
    }
}
