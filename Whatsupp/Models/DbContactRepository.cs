using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Whatsupp.Models
{
    public class DbContactRepository : IContactRepository
    {
        private WhatsuppContext ctx = new WhatsuppContext();

        public IEnumerable<Contact> GetAllContacts(int AccountId)
        {
            return ctx.Contacts.Where(c => (c.OwnerAccountId == AccountId)).ToList();
        }

        public Contact GetContact(int contactId)
        {           
            return ctx.Contacts.SingleOrDefault(c => c.Id == contactId);            
        }

        public void AddContact(Contact contact)
        {
            
                Account found = ctx.Accounts.SingleOrDefault(c => c.email == contact.email);
                contact.ContactAccountId = found.Id;
                ctx.Contacts.Add(contact);
                ctx.SaveChanges();
                   
        }

        public bool CheckContact(Contact contact)
        {
            foreach (var c in ctx.Accounts)
            {
                if (c.email == contact.email)
                {
                    return true;
                }
            }
            return false;
         //check if there is an account with contact.id   
        }

        public void Update(Contact contact)
        {
            
            Contact ocontact = ctx.Contacts.Find(contact.Id);
            if (ocontact != null)
            {
                ocontact.name = contact.name;
                ocontact.email = contact.email;
                ctx.SaveChanges();
            }
            
            
        }

        public void Remove(Contact contact)
        {
            Contact ocontact = ctx.Contacts.Find(contact.Id);
            if (ocontact != null)
            {
                ctx.Contacts.Remove(ocontact);
                ctx.SaveChanges();
            }
            
        }
    
       
         
    }
}