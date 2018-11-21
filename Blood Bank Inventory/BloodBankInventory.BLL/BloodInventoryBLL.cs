using BloodBankInventory.DAL;
using BloodBankInventory.Entity;
using BloodBankInventory.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankInventory.BLL
{
    public class BloodInventoryBLL
    {
        public DataTable BloodInventoryDisplay()
        {
            try
            {
                BloodInventoryDAL bid = new BloodInventoryDAL();
                return bid.BloodInventoryDisplay();
            }
            catch (BloodInventoryException)
            {
                throw;
            }
        }

        public bool DeleteBloodInventory(DateTime ExpiryDate)
        {
            try
            {
                BloodInventoryDAL bid = new BloodInventoryDAL();
                return bid.DeleteBloodInventory(ExpiryDate);
            }
            catch (BloodInventoryException)
            {
                throw;
            }
        }
        public bool EditBloodInventory(BloodInventory pobj)
        {
            try
            {
                BloodInventoryDAL pd = new BloodInventoryDAL();
                return pd.EditBloodInventory(pobj);
            }
            catch (BloodInventoryException)
            {
                throw;
            }
        }


        public BloodInventory Search(int searchInventory)
        {
            try
            {
                BloodInventoryDAL pd = new BloodInventoryDAL();
                return pd.Search(searchInventory);
            }
            catch (BloodInventoryException)
            {
                throw;
            }
        }

    }
}
