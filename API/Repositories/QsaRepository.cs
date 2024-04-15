using CompanyInfo.Contexts;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class QsaRepository : IQsaRepository
    {
        private readonly CompanyContext _companyContext;
        public QsaRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<Qsa>> GetAllAsync()
        {
            return await _companyContext.Qsas.ToListAsync();
        }

        public Task Create(int companyId, string name)
        {
            Qsa qsa = new Qsa
            {
                IdEmpresa = companyId,
                Nome = name
            };
            return Create(qsa);
        }
        public async Task Create(Qsa qsa)
        {
            _companyContext.Qsas.Add(qsa);
            await _companyContext.SaveChangesAsync();
            //return Task.CompletedTask;
        }
    }
}
