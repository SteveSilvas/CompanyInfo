using CompanyInfo.DTOs;

namespace CompanyInfo.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<CompanyInfoDTO>> GetAllAsync();
    }
}
