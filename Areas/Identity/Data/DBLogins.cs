using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;

namespace SerwisMotoryzacyjny.Areas.Identity.Data;

public class DBLogins : IdentityDbContext<SerwisMotoryzacyjnyUser>
{
    public DBLogins(DbContextOptions<DBLogins> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SerwisMotoryzacyjnyUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SerwisMotoryzacyjnyUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.Role).HasColumnType("int").IsRequired(false);
    }
}