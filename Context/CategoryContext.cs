using Model;
using System.Data.Entity;

namespace Context
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("MubakContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}