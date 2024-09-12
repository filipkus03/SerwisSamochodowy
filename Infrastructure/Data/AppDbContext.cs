using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;
using SerwisMotoryzacyjny.Domain.Entities;
using SerwisMotoryzacyjny.Infrastructure.Data;


namespace SerwisMotoryzacyjny.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ContactConfiguration());
        }

        // Zdefiniuj DbSet dla każdej encji, którą chcesz przechowywać w bazie danych
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
    }
}
