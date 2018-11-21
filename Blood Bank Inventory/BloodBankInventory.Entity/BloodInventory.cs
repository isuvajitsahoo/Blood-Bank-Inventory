using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankInventory.Entity
{
    public class BloodInventory
    {
        public int BloodInventoryID { get; set; }
        public string BloodGroup { get; set; }
        public int NumberofBottles { get; set; }
        public int BloodBankID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int HospitalID { get; set; }

    }
}
