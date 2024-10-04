using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Models;
using BankManagementSystem.Repos;

namespace BankManagementSystem.Databases
{
    public class AccountMemoryRepo : IAccountRepo
    {
        public ObservableCollection<Account> accounts = new ObservableCollection<Account>()
        {
            new Account
            {
                AccountNumber = 3132324,
                Name = "Minnu",
                Balance = 0,
                Type = "savings",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "gdsagdhsgdhsg",
                IsActive = true,
                InterestPercentage = 0,
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            },
            new Account
            {
                AccountNumber = 3132324,
                Name = "Ashna",
                Balance = 0,
                Type = "current",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "gdsagdhsgdhsg",
                IsActive = true,
                InterestPercentage = 0,
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            }
        };

        public void Create(Account account)
        {
            accounts.Add(account);
        }

        public void UpdateAccount(int acNo , Account account)
        {
             foreach(var ac in accounts)
            {
                if (ac.AccountNumber == acNo)
                {

                }
            }
        }

        public ObservableCollection<Account> ReadAllAccount()
        {
            return accounts;
        }

        public void DeleteAccount(int acNo, Account account)
        {
            throw new NotImplementedException();
        }

        public void Deposit(int acNo, int Amount)
        {
            throw new NotImplementedException();
        }

        public void Withdrw(int acNo, int Amount)
        {
            throw new NotImplementedException();
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }
    }
}
