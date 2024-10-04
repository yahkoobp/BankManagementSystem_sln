using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BankManagementSystem.Commands;
using BankManagementSystem.Databases;
using BankManagementSystem.Models;
using BankManagementSystem.Repos;

namespace BankManagementSystem.ViewModels
{
    public delegate void DWidnowClose();
    public class AccountViewModel : ViewModelBase
    {

        private Account _newAccount = null;
        public DWidnowClose NewWindowClose;
        public DWidnowClose EditWindowClose;

        public Account NewAccount
        {
            get { return _newAccount; }
            set
            {
                _newAccount = value;
                onPropertyChanged(nameof(NewAccount));
            }
        }

        private Account _selectedAccount = null;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set { 
                _selectedAccount = value; 
                onPropertyChanged(nameof(SelectedAccount)); 
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

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }

        public AccountViewModel()
        {
            this.NewAccount = new Account
            {
                AccountNumber = 00000,
                Name = "",
                Balance = 0,
                Type = "savings",
                Email = "minnu@gmail.com",
                PhoneNumber = "5236526526",
                Address = "gdsagdhsgdhsg",
                IsActive = true,
                InterestPercentage = 0,
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            };
            CreateCommand = new RelayCommand(Create);
            UpdateCommand = new RelayCommand(Update);
        }

        public void Create()
        {
            Account newAccount = new Account
            {
                AccountNumber = NewAccount.AccountNumber,
                Name = NewAccount.Name,
                Balance = NewAccount.Balance,
                Type = NewAccount.Type,
                Email = NewAccount.Email,
                PhoneNumber = NewAccount.PhoneNumber,
                Address = NewAccount.Address,
                IsActive = NewAccount.IsActive,
                InterestPercentage = NewAccount.InterestPercentage,
                TransactionCount = NewAccount.TransactionCount,
                LastTransactionDate = NewAccount.LastTransactionDate,
            };
            var result = MessageBox.Show(messageBoxText: "Are you sure to create?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            _repo.Create(newAccount);
            this.NewAccount = new Account { AccountNumber = 0, Name = "", Balance = 0, Type = "", Email = "", PhoneNumber = "", Address = "", IsActive = false, InterestPercentage = 0, TransactionCount = 0, LastTransactionDate = DateTime.Now };
            //this.NewItenary.Id = 0;
            //..
            //this.NewItenary = NewItenary;
            result = MessageBox.Show(messageBoxText: "Created Successfully",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            if (NewWindowClose != null)
            {
                NewWindowClose();
            }
        }

        public void Update()
        {
            if (this.SelectedAccount == null)
            {
                return;
            }

            _repo.UpdateAccount(this.SelectedAccount);
            this.SelectedAccount = this.SelectedAccount;
            var result = MessageBox.Show(messageBoxText: "Updated Successfully",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            if (EditWindowClose != null)
            {
                EditWindowClose();
            }
        }
    }

}
