using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class LoginModel1
    {
        [Required(ErrorMessage = "Account email is required")]
        [Display(Name = "Account email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Account password is required")]
        [Display(Name = "Account password")]
        [DataType(DataType.Password)]
        public string password { get; set; }    
    }
}