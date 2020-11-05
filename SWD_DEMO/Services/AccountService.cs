using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public class AccountService : BaseService<Account,string>,IAccountService
    {

        public AccountService(SWDContext context) : base(context)
        {
        }

        public Account CreateAccount(Account _entity)
        {
            Add(_entity);
            return _entity;
        }

        public Account DeleteAccount(string _id)
        {
            return Delete(_id);
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return GetAll();
        }

    

        public Account UpdateAccount(Account _entity)
        {
            return Update(_entity);
        }

        public Account GetAccountByEmail(string _email)
        {
            return GetByID(_email);
        }

        public IEnumerable<Account> GetAllAccount(int pageNum)
        {
            return GetAll(pageNum);
        }
    }
}
