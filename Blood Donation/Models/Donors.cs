using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blood_Donation.Models
{
    public class Donors
    {
        [Key]
        public int DonorID { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [MaxLength(20, ErrorMessage = "Cannot be more than 20 characters.")]
        public string Contact_No { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space not allowed.")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Blood_Group { get; set; }

        public float Age { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string NID { get; set; }

        public string Area { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public DateTime Last_Donated { get; set; }
    }
}