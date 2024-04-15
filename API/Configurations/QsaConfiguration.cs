using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyInfo.Configurations
{
    public class QsaConfiguration : IEntityTypeConfiguration<Qsa>
    {
        public void Configure(EntityTypeBuilder<Qsa> builder)
        {
            builder.ToTable("Qsa");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.IdEmpresa)
                .HasColumnName("IdEmpresa")
                .IsRequired();

            builder.HasOne(a => a.Empresa)
                .WithMany(e => e.Qsas)
                .HasForeignKey(a => a.IdEmpresa)
                .IsRequired();
        }
    }
}
