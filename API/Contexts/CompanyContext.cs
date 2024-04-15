using CompanyInfo.Configurations;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Contexts
{
    public class CompanyContext : DbContext
    {
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<AtividadeXEmpresa> AtividadesXEmpresas { get; set; }
        public virtual DbSet<Qsa>? Qsas { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new AtividadeXEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new QsaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
