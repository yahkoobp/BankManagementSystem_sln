using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Exceptions
{
    public class AccountException : Exception
    {
        public AccountException() : base() { }

        public AccountException(string message) : base(message) { }

        public AccountException(string message, Exception innerException) : base(message, innerException) { }

        public AccountException(string message, string accountNumber, string accountName) : base(message)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
        }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public override string ToString()
        {
            return $"AccountException: {Message} - Account Number: {AccountNumber} - Account Name: {AccountName}";
        }
    }
}
