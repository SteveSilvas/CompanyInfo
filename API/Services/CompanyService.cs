using CompanyInfo.DTOs;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;

namespace CompanyInfo.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGetCompanyInfo _getCompanyInfo;
        public CompanyService() {
            //_getCompanyInfo = getCompanyInfo;
            _getCompanyInfo = new GetCompanyWithCnpjWS();
        }
        public async Task<CompanyInfoDTO> GetCompanyInfoAsync(string cnpj)
        {
            if (CNPJValidator.IsValid(cnpj))
                throw new Exception("CNPJ inválido.");
            return await _getCompanyInfo.GetAsync(cnpj);
        }
    }
}
