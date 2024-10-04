using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public Decimal Balance { get; set; }
        public string Type { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public bool IsActive{ get; set; }
        public int InterestPercentage  { get; set; }
        public int TransactionCount { get; set; }
        public DateTime LastTransactionDate { get; set; }

    }
}
