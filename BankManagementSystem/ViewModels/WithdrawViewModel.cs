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
using BankManagementSystem.Exceptions;

namespace BankManagementSystem.ViewModels
{
    /// <summary>
    /// Represents a view model for withdrawing money from an account.
    /// </summary>
    public class WithdrawViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the amount to withdraw.
        /// </summary>
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

        /// <summary>
        /// Gets the accounts repository.
        /// </summary>
        private IAccountRepo _repo = AccountMemoryRepo.Instance;

        /// <summary>
        /// Gets the command for withdrawing money from an account.
        /// </summary>
        public ICommand WithdrawCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawViewModel"/> class.
        /// </summary>
        public WithdrawViewModel()
        {
            WithdrawCommand = new RelayCommand(Withdraw);
        }

        /// <summary>
        /// Withdraws money from an account.
        /// </summary>
        /// <exception cref="AccountException">Thrown if the account does not exist or if the balance is insufficient.</exception>
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
            try
            {
                _repo.Withdrw(AccountNumber, Amount);
                MessageBox.Show(messageBoxText: $"Withdrawed Successfully from account {AccountNumber}",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
                Logger.log.Info($"Withdrawed {Amount} rupees Successfully from account {AccountNumber}");
                this.AccountNumber = 0;
                this.Amount = 0;
            }
            catch (AccountException ae)
            {
                MessageBox.Show(messageBoxText: $"{ae.Message}",
                   caption: "Warning",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Warning);

                Logger.log.Error(ae.Message);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.Message);
            }
        }
    }
}
