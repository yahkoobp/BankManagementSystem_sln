﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Pages;

namespace BankManagementSystem
{
    public static class FormConfig
    {
        public static NewAccountWindow newAccountWindow = null;
        public static EditAccountWindow editAccountWindow = null;
        static FormConfig()
        {
            newAccountWindow = new NewAccountWindow();
            editAccountWindow = new EditAccountWindow();
        }

    }
}
