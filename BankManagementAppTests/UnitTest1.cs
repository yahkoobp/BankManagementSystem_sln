using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankManagementSystem;
using BankManagementSystem.Models;
using BankManagementSystem.Databases;
using System.Linq;

namespace BankManagementAppTests
{
    [TestClass]
    public class AccountMemoryRepoTests
    {
        private AccountMemoryRepo _repo;
        [TestInitialize]
        public void initialize()
        {
            _repo = AccountMemoryRepo.Instance;
        }
        [TestMethod]
        public void Test_ReadAllAccounts()
        {
            _repo = AccountMemoryRepo.Instance;
            var accounts = _repo.ReadAll();

            Assert.AreEqual(2, accounts.Count);
            Assert.IsTrue(accounts.Any(a => a.AccountNumber.CompareTo("1234") == 0));
            Assert.IsTrue(accounts.Any(a => a.AccountNumber.CompareTo("12345") == 0));
        }

        [TestMethod]
        public void Test_CreateAccount()
        {
            var account = new Account()
            {
                AccountNumber = "49",
                Name = "Rishwin",
                Balance = 0,
                Type = "current",
                Email = "rishwin@gmail.com",
                PhoneNumber = "5236526526",
                Address = "address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };
            _repo.Create(account);

            Assert.IsTrue(_repo.ReadAll().Any(ac => ac.AccountNumber.CompareTo("49") == 0));
        }

        [TestMethod]
        public void Test_UpdateAccount()
        {
            Account account = new Account
            {
                AccountNumber = "1234",
                Name = "Minnu",
                Balance = 0,
                Type = "savings",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "Address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            account.Address = "New Address";
            _repo.Update(account);
            Assert.AreEqual("New Address", _repo.ReadAll().First(a => a.AccountNumber.CompareTo("1234") == 0).Address);
        }
        [TestMethod]
        public void Test_Deposit()
        {
            Account account = new Account
            {
                AccountNumber = "1234",
                Name = "Minnu",
                Balance = 0,
                Type = "savings",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "Address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            _repo.Deposit(account.AccountNumber, 1000);
            Assert.AreEqual(1000 , _repo.ReadAll().First(ac => ac.AccountNumber == account.AccountNumber).Balance);
        }

        [TestMethod]
        public void Test_Withdraw()
        {
            var account = new Account()
            {
                AccountNumber = "12345",
                Name = "Ashna",
                Balance = 0,
                Type = "current",
                Email = "ashna@gmail.com",
                PhoneNumber = "5236526526",
                Address = "address",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            };

            _repo.Deposit(account.AccountNumber, 1000);
            _repo.Withdrw(account.AccountNumber, 700);
            Assert.AreEqual(300, _repo.ReadAll().First(ac => ac.AccountNumber == account.AccountNumber).Balance);

        }

    }
}
