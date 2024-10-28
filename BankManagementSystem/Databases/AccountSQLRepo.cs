﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Models;
using System.Windows;
using BankManagementSystem.Repos;
using System.Data.SqlClient;

namespace BankManagementSystem.Databases
{
    public class AccountSQLRepo :IAccountRepo
    {
        private ObservableCollection<Account> accounts { get; set; } = new ObservableCollection<Account>()
        {
            //new Account
            //{
            //    AccountNumber = 1,
            //    Name = "Test",
            //    Address="QQ",
            //    Email="qq.gmail.com"
            //}
        };
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=AccountDB;Integrated Security=True;";
        private static AccountSQLRepo _instance;

        public static AccountSQLRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountSQLRepo();
                }
                return _instance;
            }
        }

        public void Create(Account accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Accounts (AccountNumber, Name, Balance, Type, Email, PhoneNumber, Address, IsActive, InterestPercentage, TransactionCount, LastTransactionDate) " +
                                   "VALUES (@AccountNumber, @Name, @Balance, @Type, @Email, @PhoneNumber, @Address, @IsActive, @InterestPercentage, @TransactionCount, @LastTransactionDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", accModel.AccountNumber);
                    cmd.Parameters.AddWithValue("@Name", accModel.Name);
                    cmd.Parameters.AddWithValue("@Balance", accModel.Balance);
                    cmd.Parameters.AddWithValue("@Type", accModel.Type);
                    cmd.Parameters.AddWithValue("@Email", accModel.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", accModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", accModel.Address);
                    cmd.Parameters.AddWithValue("@IsActive", accModel.IsActive);
                    cmd.Parameters.AddWithValue("@InterestPercentage", accModel.InterestPercentage);
                    cmd.Parameters.AddWithValue("@TransactionCount", accModel.TransactionCount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", accModel.LastTransactionDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in creating account");
            }
        }

        public void Update(Account accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Address = @Address WHERE AccountNumber = @AccountNumber";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", accModel.AccountNumber);
                    cmd.Parameters.AddWithValue("@Address", accModel.Address);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Account doesn't exist");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in updating account");
            }
        }

        public ObservableCollection<Account> ReadAll()
        {
            try
            {

                // MessageBox.Show("0");

                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connectionString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"3{ex.Message}");

                }
                {
                    //MessageBox.Show("1");
                    string query = "SELECT * FROM Accounts";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Account account = new Account
                        {
                            AccountNumber = (string)reader["AccountNumber"],
                            Name = (string)reader["Name"],
                            Balance = (decimal)reader["Balance"],
                            Type = (string)reader["Type"],
                            Email = (string)reader["Email"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Address = (string)reader["Address"]/*,
                            IsActive = ((int)reader["IsActive"])== 1,
                            InterestPercentage = reader["InterestPercentage"].ToString(),
                            TransactionCount = (int)reader["TransactionCount"]*/
                        };

                        accounts.Add(account);
                        // MessageBox.Show("2");
                    }
                }
                return accounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"3{ex.Message} {ex.ToString()}");
                throw new AccountException($"Error reading accounts.{ex.Message}");
            }
        }

        public void Delete(Account accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Accounts WHERE AccountNumber = @AccountNumber";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", accModel.AccountNumber);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in deleting account");
            }
        }

        public void Deposit(string acNo, int Amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Balance = Balance + @Amount, LastTransactionDate = @LastTransactionDate, TransactionCount = TransactionCount + 1 WHERE AccountNumber = @AccountNumber";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", acNo);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Account not found, please input a valid account number");
                    }

                    // Update the accounts ObservableCollection
                    var account = accounts.FirstOrDefault(a => a.AccountNumber.CompareTo(acNo) == 0);
                    if (account != null)
                    {
                        account.Balance += Amount;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in deposit");
            }
        }

        public void Withdrw(string acNo, int Amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Balance = Balance - @Amount, LastTransactionDate = @LastTransactionDate, TransactionCount = TransactionCount + 1 WHERE AccountNumber = @AccountNumber AND Balance >= @Amount";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccountNumber", acNo);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Insufficient balance or account not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in withdrawal");
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            // Implementation for calculating and updating interest on account balances
            throw new NotImplementedException();
        }

    }
}
