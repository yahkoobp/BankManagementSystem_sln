using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Databases;
using BankManagementSystem.Models;
using BankManagementSystem.Repos;

namespace BankManagementSystem.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public Account _newAccount;

        public Account Account
        {
            get { return _newAccount; }
            set 
            {
                _newAccount = value; 
                onPropertyChanged(nameof(Account));
            }
        }
        private IAccountRepo _repo = new AccountMemoryRepo();
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _repo.ReadAllAccount();
            }
        }

    }
}
