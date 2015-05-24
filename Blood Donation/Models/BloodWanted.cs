using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blood_Donation.Models
{
    public class BloodWanted
    {
        [Key]
        public int WantedID { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [MaxLength(20, ErrorMessage = "Cannot be more than 20 characters.")]
        public string Contact_No { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Blood_Group { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public DateTime When_needed { get; set; }
    }
}