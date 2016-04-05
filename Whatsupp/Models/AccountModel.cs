using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Account name is required")]
        [Display(Name = "Your name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Account email is required")]
        [Display(Name = "Account email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Account password is required")]
        [Display(Name = "Account password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //[NotMapped]
        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("password", ErrorMessage = " The password and confirmation password do not match!")]
        //public string ConfirmPassword { get; set; }
        
      


        public Account()
        {

        }

        public Account(string email, string password, string name)
        {
            
            this.email = email;
            this.password = password;
            this.name = name;
        }
    }

   

   

}