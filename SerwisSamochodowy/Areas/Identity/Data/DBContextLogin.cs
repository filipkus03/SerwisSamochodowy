using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerwisSamochodowy.Areas.Identity.Data;

namespace SerwisSamochodowy.Areas.Identity.Data;

public class DBContextLogin : IdentityDbContext<SerwisSamochodowyUser>
{
    public DBContextLogin(DbContextOptions<DBContextLogin> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SerwisSamochodowyUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SerwisSamochodowyUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100) .IsRequired(false);
        builder.Property(x => x.LastName).HasMaxLength(100) .IsRequired(false);
        builder.Property(x => x.Role).HasMaxLength(100).IsRequired(false);
    }
}