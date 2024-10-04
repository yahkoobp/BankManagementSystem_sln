using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Pages;
using BankManagementSystem.ViewModels;

namespace BankManagementSystem
{
    public static class FormConfig
    {
        public static NewAccountWindow newAccountWindow = null;
        public static EditAccountWindow editAccountWindow = null;
        public static AccountViewModel accountViewModel = null;
        static FormConfig()
        {
            accountViewModel = new AccountViewModel();
            newAccountWindow = new NewAccountWindow();
            editAccountWindow = new EditAccountWindow();
            
        }

    }
}
