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
using BankManagementSystem.Exceptions;
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

        


        private IAccountRepo _repo = AccountMemoryRepo.Instance;
        public ObservableCollection<Account> Accounts
        {
            get
            {
                try
                {
                    return _repo.ReadAllAccount();
                }
                catch(AccountException ae)
                {
                    Logger.log.Error(ae.Message);
                    throw;
                }
                
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
                Type = "",
                Email = "",
                PhoneNumber = "",
                Address = "",
                IsActive = false,
                InterestPercentage = "0",
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
            try
            {
                _repo.Create(newAccount);
                result = MessageBox.Show(messageBoxText: "Created Successfully",
                   caption: "Alert",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Information);
                Logger.log.Info($"An account with acoount number {newAccount.AccountNumber} has been created successfully");
                this.NewAccount = new Account { AccountNumber = 0, Name = "", Balance = 0, Type = "", Email = "", PhoneNumber = "", Address = "", IsActive = false, InterestPercentage = "0", TransactionCount = 0, LastTransactionDate = DateTime.Now };
            }
            catch(AccountException ae)
            {
                Logger.log.Error(ae.Message);
            }

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

            try
            {
                _repo.UpdateAccount(this.SelectedAccount);
                this.SelectedAccount = this.SelectedAccount;
                var result = MessageBox.Show(messageBoxText: $"Account {SelectedAccount.AccountNumber} is updated successfully",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
                Logger.log.Info($"Account {SelectedAccount.AccountNumber} is updated successfully");
            }
            catch(AccountException ae)
            {
                Logger.log.Error(ae.Message);
            }
            

            if (EditWindowClose != null)
            {
                EditWindowClose();
            }
        }


        
    }

}
