using CompanyInfo.Contexts;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _companyContext;
        public CompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<Empresa>> GetAllAsync()
        {
            return await _companyContext.Empresas.ToListAsync();
        }

        public Empresa? GetByCNPJ(string cnpj)
        {
            return _companyContext
                .Empresas
                .Where(c => c.CNPJ == cnpj)
                .FirstOrDefault();
        }
        public async Task<int> Create(Empresa company)
        {
            _companyContext.Empresas.Add(company);

            await _companyContext.SaveChangesAsync();
            return company.Id;
        }
    }
}
