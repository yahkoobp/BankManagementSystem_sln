using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Models;
using BankManagementSystem.Repos;

namespace BankManagementSystem.Databases
{
    public class AccountMemoryRepo : IAccountRepo
    {
        private static AccountMemoryRepo _instance;
        private ObservableCollection<Account> accounts;

        private AccountMemoryRepo()
        {
            accounts = new ObservableCollection<Account>();
            InitializeAccounts();
        
        }

        private void InitializeAccounts()
        {
            accounts.Add(new Account
            {
                AccountNumber = 1234,
                Name = "Minnu",
                Balance = 0,
                Type = "savings",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "gdsagdhsgdhsg",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            });
            accounts.Add(new Account
            {
                AccountNumber = 3132324,
                Name = "Ashna",
                Balance = 0,
                Type = "current",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "gdsagdhsgdhsg",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            });
        }

        public static AccountMemoryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountMemoryRepo();
                }
                return _instance;
            }
        }


        public void Create(Account account)
        {
            try
            {
                accounts.Add(account);
            }
            catch(AccountException ae)
            {
                throw new AccountException("Error in creating account");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                var existingAccount = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
                if (existingAccount != null)
                {
                    existingAccount.Address = account.Address;
                }
                else
                {
                    throw new AccountException("Account doesn't exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ObservableCollection<Account> ReadAllAccount()
        {
            try
            {
                return accounts;
            }
            catch(AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void DeleteAccount(int acNo, Account account)
        {
            throw new NotImplementedException();
        }

        public void Deposit(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccountNumber == acNo);
                if (account != null)
                {
                    account.Balance = account.Balance + Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Withdrw(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccountNumber == acNo);
                if (account != null)
                {
                    if (account.Balance < Amount)
                    {
                        throw new AccountException("Insufficient balance");
                        
                    }
                    account.Balance = account.Balance - Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;               

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }
    }
}
