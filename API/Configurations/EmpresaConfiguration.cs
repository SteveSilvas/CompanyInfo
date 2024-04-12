using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyInfo.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.CNPJ)
                .HasColumnName("CNPJ")
                .IsRequired();

            builder.Property(a => a.Abertura)
                .HasColumnName("Abertura")
                .IsRequired();

            builder.Property(a => a.CEP)
             .HasColumnName("CEP")
             .IsRequired();

            builder.Property(a => a.Bairro)
                .HasColumnName("Bairro");

            builder.Property(a => a.Status)
                .HasColumnName("Status");

            //builder.Property(a => a.AtividadePrincipal)
            //    .HasColumnName("AtividadePrincipal");

            //builder.Property(a => a.AtividadesSecundarias)
            //    .HasColumnName("AtividadesSecundarias")
            //    .IsRequired();

            builder.Property(a => a.CapitalSocial)
                .HasColumnName("CapitalSocial");

            //builder.HasOne(a => a.Billing)
            //    .WithMany()
            //    .HasForeignKey(a => a.BillingId);

            //builder.HasOne(a => a.Id)
            //    .WithMany()
            //    .HasForeignKey(a => a.StateId);
        }
    }
}
