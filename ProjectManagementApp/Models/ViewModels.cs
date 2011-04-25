using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Models
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name="Email")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
    }

    public class DashboardViewModel
    {
        [Required]
        public Micropost Micropost { get; set; }

        public List<Micropost> Microposts { get; set; }
    }
}