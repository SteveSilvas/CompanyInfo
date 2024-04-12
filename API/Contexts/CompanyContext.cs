using CompanyInfo.Configurations;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Contexts
{
    public class CompanyContext: DbContext
    {
        public virtual DbSet<Empresa> Companies { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=C:\\Users\\Ferreiras\\OneDrive\\Documentos\\_steve_working\\CompanyInfo\\API\\bin\\Debug\\net6.0\\sqlitedb1", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
