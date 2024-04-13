using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface IActivityXCompanyRepository
    {
        public Task<List<AtividadeXEmpresa>> GetAllAsync();

        public Task Create(int activityId, int companyId);

        public Task Create(AtividadeXEmpresa activityXCompany);
    }
}
