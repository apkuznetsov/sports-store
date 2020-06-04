﻿using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
