using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blood_Donation.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("BloodDonationtest3")
        {
        }

        public DbSet<Donors> donor { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<BloodWanted> wanted { get; set; }
    }
}