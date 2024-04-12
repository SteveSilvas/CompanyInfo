using CompanyInfo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<CompanyInfoDTO>> GetAllAsync();

        public Task Create(CompanyInfoDTO companyInfoDTO);
    }
}
