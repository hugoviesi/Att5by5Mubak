using Model;
using System.Data.Entity;

namespace Context
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("MubakContext")
        {

        }

        public DbSet<Address> Addresses { get; set; }
    }
}
