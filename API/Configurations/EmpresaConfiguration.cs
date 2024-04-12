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

            builder.Property(a => a.Abertura)
                .HasColumnName("Abertura")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Situacao)
                .HasColumnName("Situacao")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Tipo)
                .HasColumnName("Tipo")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Fantasia)
                .HasColumnName("Fantasia")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Porte)
                .HasColumnName("Porte")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.NaturezaJuridica)
                .HasColumnName("NaturezaJuridica")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Municipio)
                .HasColumnName("Municipio")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.UF)
                .HasColumnName("UF")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.DataSituacao)
                .HasColumnName("DataSituacao")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.CNPJ)
                .HasColumnName("CNPJ")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.UltimaAtualizacao)
                .HasColumnName("UltimaAtualizacao")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.EFR)
                .HasColumnName("EFR")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.MotivoSituacao)
                .HasColumnName("MotivoSituacao")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.SituacaoEspecial)
                .HasColumnName("SituacaoEspecial")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.DataSituacaoEspecial)
                .HasColumnName("DataSituacaoEspecial")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(a => a.CapitalSocial)
                .HasColumnName("CapitalSocial")
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}
