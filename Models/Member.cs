using System;
using System.ComponentModel.DataAnnotations;

namespace Eder.Models
{
    public class Member
    {
        public int Id {get; set;}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set;}
    }
}