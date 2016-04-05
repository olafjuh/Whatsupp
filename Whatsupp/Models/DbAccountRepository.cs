using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class DbAccountRepository : IAccountRepository
    {
        private WhatsuppContext ctx = new WhatsuppContext();
        

        public Account GetAccount(string email, string password)
        {
            Account gevonden = ctx.Accounts.FirstOrDefault(a => a.email == email && a.password == password);            
            return gevonden;
        }

        public void RegisterAccount(RegisterModel model)
        {
            Account account = new Account();
            account.name = model.name;
            account.password = model.password;
            account.email = model.email;
            ctx.Accounts.Add(account);
            ctx.SaveChanges();
        }
    }
}