using CompanyInfo.Contexts;
using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyInfo.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _companyContext;
        public CompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<List<CompanyInfoDTO>> GetAllAsync()
        {
            var companiesOfDB = await _companyContext.Empresas.ToListAsync();
            List<CompanyInfoDTO> result = new List<CompanyInfoDTO>();

            foreach (var company in companiesOfDB)
            {
                result.Add(new CompanyInfoDTO
                {
                    Id = company.Id,
                    Fantasia = company.Fantasia,
                    Nome = company.Nome,
                    CNPJ = company.CNPJ,
                    Porte = company.Porte,
                    CapitalSocial = company.CapitalSocial,
                    Email = company.Email,
                    Telefone = company.Telefone,
                    Abertura = company.Abertura,
                    Status = company.Status,
                    Situacao = company.Situacao,
                    MotivoSituacao = company.MotivoSituacao,
                    DataSituacao = company.DataSituacao,
                    SituacaoEspecial = company.DataSituacaoEspecial,
                    DataSituacaoEspecial = company.DataSituacaoEspecial,
                    NaturezaJuridica = company.NaturezaJuridica,
                    //AtividadePrincipal = company.AtividadePrincipal,
                    //AtividadesSecundarias = company.AtividadesSecundarias,
                    CEP = company.CEP,
                    Logradouro = company.Logradouro,
                    Numero = company.Numero,
                    Complemento = company.Complemento,
                    Bairro = company.Bairro,
                    Municipio = company.Municipio,
                    UF = company.UF,
                    //Billing = company.Bling
                    EFR = company.EFR,
                    //QSA = company.QSA,
                    //Extra = company.Extra
                    Tipo = company.Tipo,
                    UltimaAtualizacao = company.UltimaAtualizacao,

                });
            }

            return result;
        }

        public Empresa? GetByCNPJ(string cnpj)
        {
            return  _companyContext
                .Empresas
                .Where(c => c.CNPJ == cnpj)
                .FirstOrDefault();
        }
        public async Task<int> Create(Empresa company)
        {
            _companyContext.Empresas.Add(company);

            await _companyContext.SaveChangesAsync();
            return company.Id;
        }
    }
}
