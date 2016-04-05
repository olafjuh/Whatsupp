using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public interface IAccountRepository
    {
        Account GetAccount(string name, string password);
        void RegisterAccount(RegisterModel model);
    }
}