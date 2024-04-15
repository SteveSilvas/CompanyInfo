using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface IQsaRepository
    {
        public Task<List<Qsa>> GetAllAsync();

        public Task Create(int companyId, string name);

        public Task Create(Qsa qsa);
    }
}
