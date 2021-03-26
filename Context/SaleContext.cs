using Model;
using System.Data.Entity;

namespace Context
{
    public class SaleContext : DbContext
    {
        public SaleContext() : base("MubakContext")
        {

        }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<ItemProduct> ItemProducts { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
