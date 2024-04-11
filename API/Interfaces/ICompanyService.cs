using CompanyInfo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Interfaces
{
    public interface ICompanyService
    {
        public Task<CompanyInfoDTO> GetCompanyInfoAsync(string cnpj);
    }
}
