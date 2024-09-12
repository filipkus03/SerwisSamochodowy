using System.ComponentModel.DataAnnotations;
using global::SerwisMotoryzacyjny.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;

namespace SerwisMotoryzacyjny.Domain.Entities
{
    

    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Message).HasMaxLength(250).IsRequired(false);

        }
    }
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
