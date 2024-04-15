using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyInfo.Configurations
{
    public class AtividadeXEmpresaConfiguration : IEntityTypeConfiguration<AtividadeXEmpresa>
    {
        public void Configure(EntityTypeBuilder<AtividadeXEmpresa> builder)
        {
            builder.ToTable("AtividadeXEmpresa");

            builder.HasKey(ae => ae.Id);

            builder.Property(ae => ae.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(ae => ae.Tipo)
               .HasColumnName("Tipo")
               .IsRequired();

            builder.HasOne(ae => ae.Empresa)
                .WithMany(e => e.AtividadesXEmpresas)
                .HasForeignKey(ae => ae.IdEmpresa)
                .IsRequired();

            builder.HasOne(ae => ae.Atividade)
                .WithMany(a => a.AtividadesXEmpresas)
                .HasForeignKey(ae => ae.IdAtividade)
                .IsRequired();
        }
    }
}
