using CompanyInfo.Contexts;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class ActivityXCompanyRepository : IActivityXCompanyRepository
    {
        private readonly CompanyContext _companyContext;
        public ActivityXCompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public Task Create(int activityId, int companyId)
        {
            AtividadeXEmpresa activityXCompany = new AtividadeXEmpresa
            {
                IdAtividade = activityId,
                IdEmpresa = companyId
            };
            return Create(activityXCompany);
        }

        public Task Create(AtividadeXEmpresa activityXCompany)
        {
            _companyContext.AtividadesXEmpresas.Add(activityXCompany);
            _companyContext.SaveChangesAsync();

            return Task.CompletedTask;
        }

        Task<List<AtividadeXEmpresa>> IActivityXCompanyRepository.GetAllAsync()
        {
            return _companyContext.AtividadesXEmpresas.ToListAsync();
        }
    }
}
