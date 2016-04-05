using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatsupp.Models
{
    
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Contact voornaam is required")]
        [Display(Name = "Contact voornaam")]
        public String name { get; set; }

        [Required(ErrorMessage = "Contact Email is required")]
        [Display(Name = "Contact email")]
        public String email { get; set; }

        public int OwnerAccountId { get; set; }

        public int? ContactAccountId { get; set; }

        public Contact()
        {

        }

        public Contact(string name, string email)
        {
            /*this.id++;
            this.nummer = b;*/
            this.name = name;
            this.email = email;
        }
        /*
        public Contact(int a, int b, string c, string d)
        {
            this.Id = a;
            //this.nummer = b;
            this.voorNaam = c;
            this.achterNaam = d;
        }*/
    }
}
