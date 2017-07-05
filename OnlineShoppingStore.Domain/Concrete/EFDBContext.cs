using OnlineShoppingStore.Domain.Entity;
using System.Data.Entity;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EFDBContext:DbContext
    {
       public DbSet<Product> Products { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<UserProfile> UserProfile { get; set; }
    }
}
