using CompanyInfo.Contexts;
using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class CompanyRepository :ICompanyRepository
    {
        private readonly CompanyContext _companyContext;
        public CompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<CompanyInfoDTO>> GetAllAsync()
        {
            var companiesOfDB = await _companyContext.Companies.ToListAsync();
            List<CompanyInfoDTO> result = new List<CompanyInfoDTO>();
          

            foreach (var company in companiesOfDB)
            {
                result.Add(new CompanyInfoDTO
                {
                    CNPJ = company.CNPJ,
                    // Adicione outros campos conforme necessário
                });
            }

            return result;
        }

    }
}
