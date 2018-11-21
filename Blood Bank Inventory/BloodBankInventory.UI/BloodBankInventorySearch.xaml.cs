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
using BloodBankInventory.Entity;
using BloodBankInventory.BLL;
using BloodBankInventory.DAL;
using BloodBankInventory.Exceptions;

namespace BloodBankInventory.UI
{
    /// <summary>
    /// Interaction logic for BloodBankInventorySearch.xaml
    /// </summary>
    public partial class BloodBankInventorySearch : Window
    {
        public BloodBankInventorySearch()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodInventoryBLL pb = new BloodInventoryBLL();
                BloodInventory p = pb.Search(int.Parse(SearchtextBox.Text));
                if (p != null)
                {
                    BloodGrouptextBox.Text = p.BloodGroup;
                    txtBloodBankId.Text = p.BloodBankID.ToString();
                    txtNoOfBottles.Text = p.NumberofBottles.ToString();
                    txtExpiryDate.Text = p.ExpiryDate.ToShortDateString();
                    txtHospitalId.Text = p.HospitalID.ToString();
                    groupBox.Visibility = Visibility.Visible;
                }
                else
                {
                    groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show
                        (string.Format("Blood Inventory with id {0} does not exists.", SearchtextBox.Text),
                        "Blood Inventory Management System");
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

        private void Updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodInventory p = new BloodInventory()
                {
                    BloodInventoryID = int.Parse(SearchtextBox.Text), 
                    BloodGroup = BloodGrouptextBox.Text,
                    NumberofBottles = int.Parse(txtNoOfBottles.Text),
                    BloodBankID = int.Parse(txtBloodBankId.Text),
                    ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text),
                    HospitalID = int.Parse(txtHospitalId.Text)
                };
                BloodInventoryBLL pb = new BloodInventoryBLL();
                if (pb.EditBloodInventory(p))
                {
                   groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show("Inventory data updated.", "BBMS");
                }
            }
            catch (BloodInventoryException ex)
            {
                MessageBox.Show(ex.Message, "BBMS");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "BBMS");
            }


        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime pid = DateTime.Parse(txtExpiryDate.Text);
                BloodInventoryBLL pb = new BloodInventoryBLL();
                if (pb.DeleteBloodInventory(pid))
                {
                    groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show("Blood Inventory Id " + pid + " was deleted.");
                }
            }
            catch (BloodInventoryException ex)
            {
                MessageBox.Show(ex.Message, "Product Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Product Management System");
            }
        }
    }
}
