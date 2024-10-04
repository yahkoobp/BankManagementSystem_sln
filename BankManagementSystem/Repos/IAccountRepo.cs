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
        void AddAccount(Account account);
        void UpdateAccount(int acNo , Account account);

        ObservableCollection<Account> ReadAllAccount();

    }
}
