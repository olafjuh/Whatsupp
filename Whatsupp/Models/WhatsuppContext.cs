using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class WhatsuppContext : DbContext
    {
        public WhatsuppContext()
            : base("WhatsUppConnection")
        {
            
        }

        public DbSet<Whatsupp.Models.Contact> Contacts { get; set; }
        public DbSet<Whatsupp.Models.Account> Accounts { get; set; }
        public DbSet<Whatsupp.Models.Message> AccountChats { get; set; }
        
        //public DbSet<Group> Groups { get; set; }
    }
}