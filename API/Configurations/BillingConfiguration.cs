using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyInfo.Configurations
{
    public class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.ToTable("Billing");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Database)
                .HasColumnName("Database")
                .IsRequired();

            builder.Property(a => a.Free)
                .HasColumnName("Free")
                .IsRequired();
        }
    }
}
