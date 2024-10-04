using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repos
{
    public interface IAccountRepo
    {
        void Create(Account account);
        void UpdateAccount(int acNo , Account account);

        void DeleteAccount(int acNo , Account account);
        void Deposit(int acNo , int Amount);
        void Withdrw(int acNo , int Amount);
        void CalculateInterestAndUpdateBalance();
        ObservableCollection<Account> ReadAllAccount();

    }
}
