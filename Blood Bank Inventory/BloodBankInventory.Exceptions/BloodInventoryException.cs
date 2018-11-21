using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankInventory.Exceptions
{
    public class BloodInventoryException : ApplicationException
    {
        public BloodInventoryException() : base()
        {
        }

        public BloodInventoryException(string message) : base(message)
        {
        }

        public BloodInventoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
