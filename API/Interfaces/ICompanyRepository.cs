using CompanyInfo.DTOs;
using CompanyInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<CompanyInfoDTO>> GetAllAsync();

        public Task Create(Empresa company);
    }
}
