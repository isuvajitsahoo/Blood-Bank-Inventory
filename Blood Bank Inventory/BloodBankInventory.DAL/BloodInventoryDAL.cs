using BloodBankInventory.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankInventory.Entity;

namespace BloodBankInventory.DAL
{
    public class BloodInventoryDAL
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;



        static BloodInventoryDAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        public BloodInventoryDAL()
        {
            con = new SqlConnection(conStr);

        }

        public DataTable BloodInventoryDisplay()
        {
            DataTable dt = null;

            try
            {
                // con = new SqlConnection();
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspGetBloodBanks";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodInventoryException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }


        public bool DeleteBloodInventory(DateTime ExpiryDate)
        {
            bool result = false;
            try
            {
               
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspDeleteBloodInventory";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExpiryDate", ExpiryDate);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (BloodInventoryException)
            { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public bool EditBloodInventory(BloodInventory pboj)
        {
            bool result = false;
            try
            {
                // con = new SqlConnection();
                //   con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspEditBloodInventory";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@bId", pboj.BloodInventoryID);
                cmd.Parameters.AddWithValue("@bloodGroup", pboj.BloodGroup);
                cmd.Parameters.AddWithValue("@noOfBottles", pboj.NumberofBottles);
                cmd.Parameters.AddWithValue("@bloodBankId", pboj.BloodBankID);
                cmd.Parameters.AddWithValue("@expiryDate", pboj.ExpiryDate);
                cmd.Parameters.AddWithValue("@hid", pboj.HospitalID);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (BloodInventoryException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public BloodInventory Search(int searchInventory)
        {
            BloodInventory p = null;

            try
            {
                //  con = new SqlConnection();
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspSearchBloodInventory";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bId", searchInventory );

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new BloodInventory
                    {

                        BloodGroup = dr["BloodGroup"].ToString(),
                        NumberofBottles = int.Parse(dr["NumberOfBottle"].ToString()),
                        BloodBankID = int.Parse(dr["BloodBankId"].ToString()),
                        ExpiryDate = DateTime.Parse((dr["ExpiryDate"].ToString())),
                        HospitalID = int.Parse(dr["HospitalId"].ToString())
                    };
                    dr.Close();
                }
            }
            catch (BloodInventoryException) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return p;
        }
    }
}
