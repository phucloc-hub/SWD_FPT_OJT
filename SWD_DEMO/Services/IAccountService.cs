using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IAccountService : IBaseService<Account,string>
    {
        Account CreateAccount(Account _entity);
        Account UpdateAccount(Account _entity);
        Account DeleteAccount(string _id);

        Account GetAccountByEmail(string _email);
        IEnumerable<Account> GetAllAccount();


    }
}
