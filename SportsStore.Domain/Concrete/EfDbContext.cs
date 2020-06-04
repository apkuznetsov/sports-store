using Microsoft.EntityFrameworkCore;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
