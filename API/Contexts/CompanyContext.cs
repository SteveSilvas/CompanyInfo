﻿using CompanyInfo.Configurations;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Contexts
{
    public class CompanyContext: DbContext
    {
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeConfiguration());
            modelBuilder.ApplyConfiguration(new BillingConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
