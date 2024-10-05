using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Commands;
using BankManagementSystem.Databases;
using BankManagementSystem.Repos;
using System.Windows.Input;
using System.Windows;

namespace BankManagementSystem.ViewModels
{
    public class WithdrawViewModel : ViewModelBase
    {
        private int _accountNumber;
        public int AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = value;
                onPropertyChanged(nameof(AccountNumber));
            }

        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                onPropertyChanged(nameof(Amount));
            }
        }

        private IAccountRepo _repo = AccountMemoryRepo.Instance;

        public ICommand WithdrawCommand { get; }

        public WithdrawViewModel()
        {
            WithdrawCommand = new RelayCommand(Withdraw);
        }

        public void Withdraw()
        {
            var result = MessageBox.Show(messageBoxText: "Are you sure to Withdraw?",
                   caption: "Confirm",
                   button: MessageBoxButton.YesNo,
                   icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            _repo.Withdrw(AccountNumber, Amount);
            this.AccountNumber = 0;
            this.Amount = 0;
        }
    }
}
