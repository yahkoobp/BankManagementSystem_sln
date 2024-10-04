using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repos
{
    public interface IAccountRepo
    {
        void AddAccount(Account account);
        void UpdateAccount(Account account);

    }
}
