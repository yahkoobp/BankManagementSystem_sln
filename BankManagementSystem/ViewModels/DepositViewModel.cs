using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Databases;
using BankManagementSystem.Models;
using BankManagementSystem.Repos;
using System.Windows.Input;
using BankManagementSystem.Commands;
using System.Windows;
using BankManagementSystem.Exceptions;

namespace BankManagementSystem.ViewModels
{
    /// <summary>
    /// Represents a view model for depositing money into an account.
    /// </summary>
    public class DepositViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = value;
                onPropertyChanged(nameof(AccountNumber));
            }
        }

        /// <summary>
        /// Gets or sets the amount to deposit.
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
        /// Gets the command for depositing money into an account.
        /// </summary>
        public ICommand DepositCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositViewModel"/> class.
        /// </summary>
        public DepositViewModel()
        {
            DepositCommand = new RelayCommand(Deposit);
        }

        /// <summary>
        /// Deposits money into an account.
        /// </summary>
        public void Deposit()
        {
            var result = MessageBox.Show(messageBoxText: "Are you sure to Deposit?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            try
            {
                _repo.Deposit(AccountNumber, Amount);
                MessageBox.Show(messageBoxText: $"Deposited Successfully to account {AccountNumber}",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
                Logger.log.Info($"Deposited {Amount} rupees Successfully to account {AccountNumber}");
                this.AccountNumber = "0";
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
