using ExamFereshteh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ExamFereshteh.DAL
{
    public class ProductContext:DbContext
    {
        public ProductContext() : base("ProductContext")
        {
            Database.SetInitializer<ProductContext>(null);
        }

        public DbSet<Rate> Rates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}