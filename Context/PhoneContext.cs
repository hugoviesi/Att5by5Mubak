using Model;
using System.Data.Entity;

namespace Context
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("MubakContext")
        {

        }

        public DbSet<Phone> Phones { get; set; }
    }
}
