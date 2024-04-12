using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyInfo.Configurations
{
    public class AtividadeConfiguration : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividade");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Code)
                .HasColumnName("Code")
                .IsRequired();

            builder.Property(a => a.Text)
                .HasColumnName("Text")
                .IsRequired();
        }
    }
}
