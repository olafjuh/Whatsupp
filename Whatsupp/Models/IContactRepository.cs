using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts(int accountId);
        Contact GetContact(int contactId);
        bool CheckContact(Contact contact);
        void AddContact(Contact c);
        void Update(Contact c);
        void Remove(Contact c);
        
    }
}