using Microsoft.EntityFrameworkCore;
using CarService.Core;
using System.Collections.Generic;

namespace CarService.Infrastructure
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
