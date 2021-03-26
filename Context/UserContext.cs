using Model;
using System.Data.Entity;

namespace Context
{
    public class UserContext : DbContext
    {
        public UserContext() : base("MubakContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
