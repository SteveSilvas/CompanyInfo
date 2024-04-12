using CompanyInfo.Contexts;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly CompanyContext _companyContext;
        public AtividadeRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<Atividade>> GetAllAsync()
        {
            return await _companyContext.Atividades.ToListAsync();
        }

    }
}
