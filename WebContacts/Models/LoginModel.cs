using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebContacts.Models
{
    public class LoginModel
    {
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}