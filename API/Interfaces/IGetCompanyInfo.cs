using CompanyInfo.DTOs;

namespace CompanyInfo.Interfaces
{
    public interface IGetCompanyInfo
    {
        public Task<CompanyInfoDTO> GetAsync(string cnpj);
    }
}
