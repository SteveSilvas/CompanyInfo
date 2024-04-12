using CompanyInfo.DTOs;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyInfo.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGetCompanyInfo _getCompanyInfo;
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository, IGetCompanyInfo getCompanyInfo)
        {
            _getCompanyInfo = getCompanyInfo;
            _companyRepository = companyRepository;
        }
        public async Task<CompanyInfoDTO> GetCompanyInfoAsync(string cnpj)
        {
            if (!CNPJValidator.IsValid(cnpj))
                throw new Exception("CNPJ inválido.");
            return await _getCompanyInfo.GetAsync(cnpj);
        }

        public async Task<List<CompanyInfoDTO>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public Task Create(CompanyInfoDTO companyInfoDTO)
        {
            return _companyRepository.Create(companyInfoDTO);
        }
    }
}
