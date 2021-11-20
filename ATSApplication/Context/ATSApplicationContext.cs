using ATSApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ATSApplication.Context
{
    public class ATSApplicationContext : DbContext
    {
        public ATSApplicationContext() : base("DefaultConnection")
        {
            //Database.SetInitializer<WebBasedCMSContext>(null);
        }
          public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<CourierDetails_Error> CourierDetails_Error { get; set; }
        //public DbSet<CourierDetails> CourierDetails { get; set; }
        //public DbSet<OrderStatusMaster> OrderStatusMaster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}