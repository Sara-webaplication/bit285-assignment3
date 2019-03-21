using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using bit285_assignment3_api.Models;

namespace bit285_assignment3_api.ViewModels
{
    public class Login
    {
        [Display(Name = "Username (Email)")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Display(AutoGenerateField =true)]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
