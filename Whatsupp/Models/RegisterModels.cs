using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class RegisterModel
    {
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

        [Required(ErrorMessage = "Account password is required")]
        [Display(Name = "Account password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match")]
        public string confirmPassword { get; set; }
    }
}