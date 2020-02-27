using ExamFereshteh.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


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