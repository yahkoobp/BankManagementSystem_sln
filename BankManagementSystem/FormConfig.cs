using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Pages;
using BankManagementSystem.ViewModels;

namespace BankManagementSystem
{
    class A : IDataErrorInfo
    {
        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();
    }

    public static class FormConfig
    {
        public static AccountViewModel accountViewModel = null;
        public static DepositViewModel depositViewModel = null;
        public static WithdrawViewModel withdrawViewModel = null;
        public static NewAccountWindow newAccountWindow = null;
        public static EditAccountWindow editAccountWindow = null; 
        public static DepositWindow depositWindow = null;
        public static AccountListWindow accountListWindow = null;
        public static WithdrawWindow withdrawWindow = null;
        public static DashBoardWindow dashBoardWindow = null;
        public static AccountViewWindow accountViewWindow = null;
        
        static FormConfig()
        {
            accountViewModel = new AccountViewModel();
            depositViewModel = new DepositViewModel();
            withdrawViewModel = new WithdrawViewModel();
            editAccountWindow = new EditAccountWindow();
            newAccountWindow = new NewAccountWindow();
            depositWindow = new DepositWindow();
            accountListWindow = new AccountListWindow();
            withdrawWindow = new WithdrawWindow();
            dashBoardWindow = new DashBoardWindow();
            accountViewWindow = new AccountViewWindow();

            
        }

    }
}
