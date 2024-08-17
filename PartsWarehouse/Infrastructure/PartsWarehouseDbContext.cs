using Microsoft.EntityFrameworkCore;
using PartsWarehouse.Core;
using System.Collections.Generic;

namespace PartsWarehouse.Infrastructure
{
    public class PartsWarehouseDbContext : DbContext
    {
        public PartsWarehouseDbContext(DbContextOptions<PartsWarehouseDbContext> options) : base(options)
        {
        }

        public DbSet<Part> Parts { get; set; }
    }
}
