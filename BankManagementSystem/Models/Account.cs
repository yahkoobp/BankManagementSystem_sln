﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class Account : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the account holder's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the account balance.
        /// </summary>
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        /// <summary>
        /// Gets or sets the account type (e.g. savings, current).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the account holder's email address.
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Gets or sets the account holder's phone number.
        /// </summary>
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the account holder's address.
        /// </summary>
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the account is active.
        /// </summary>   
        private bool _isActive;
        public bool IsActive 
        {
            get 
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            } 
        }

        /// <summary>
        /// Gets or sets the interest percentage for the account.
        /// </summary>
        public string InterestPercentage { get; set; }

        /// <summary>
        /// Gets or sets the number of transactions made on the account.
        /// </summary>
        private int _transactionCount;
        public int TransactionCount
        {
            get { return _transactionCount; }
            set
            {
                _transactionCount = value;
                OnPropertyChanged(nameof(TransactionCount));
            }
        }

        /// <summary>
        /// Gets or sets the date of the last transaction made on the account.
        /// </summary>
        private DateTime _lastTransactionDate;
        public DateTime LastTransactionDate
        {
            get { return _lastTransactionDate; }
            set
            {
                _lastTransactionDate = value;
                OnPropertyChanged(nameof(LastTransactionDate));
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
