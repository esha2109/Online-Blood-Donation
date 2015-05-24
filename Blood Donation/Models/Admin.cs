using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blood_Donation.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }


        [Required(ErrorMessage = "Cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space not allowed.")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Cannot be empty")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}