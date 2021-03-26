using Model;
using System.Data.Entity;


namespace Context
{
    public class PaymentContext : DbContext
    {
        public PaymentContext() : base ("MubakContext")
        {

        }
        public DbSet<Payment> Payments { get; set; }
    }
}
