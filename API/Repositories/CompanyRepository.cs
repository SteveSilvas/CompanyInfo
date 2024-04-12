using CompanyInfo.Contexts;
using CompanyInfo.DTOs;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
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
            var companiesOfDB = await _companyContext.Empresas.ToListAsync();
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

        public async Task Create(CompanyInfoDTO companyInfoDTO)
        {
            Empresa company = new Empresa
            {
                Abertura = companyInfoDTO.Abertura,
                Situacao = companyInfoDTO.Situacao,
                Tipo = companyInfoDTO.Tipo,
                Nome = companyInfoDTO.Nome,
                Fantasia = companyInfoDTO.Fantasia,
                Porte = companyInfoDTO.Porte,
                NaturezaJuridica = companyInfoDTO.NaturezaJuridica,
                Logradouro = companyInfoDTO.Logradouro,
                Numero = companyInfoDTO.Numero,
                Complemento = companyInfoDTO.Complemento,
                Municipio = companyInfoDTO.Municipio,
                Bairro = companyInfoDTO.Bairro,
                UF = companyInfoDTO.UF,
                CEP = companyInfoDTO.CEP,
                Telefone = companyInfoDTO.Telefone,
                DataSituacao = companyInfoDTO.DataSituacao,
                CNPJ = companyInfoDTO.CNPJ,
                UltimaAtualizacao = companyInfoDTO.UltimaAtualizacao,
                Status = companyInfoDTO.Status,
                Email = companyInfoDTO.Email,
                EFR = companyInfoDTO.EFR,
                MotivoSituacao = companyInfoDTO.MotivoSituacao,
                SituacaoEspecial = companyInfoDTO.SituacaoEspecial,
                DataSituacaoEspecial = companyInfoDTO.DataSituacaoEspecial,
                CapitalSocial = companyInfoDTO.CapitalSocial
            };


            _companyContext.Empresas.Add(company);

            await _companyContext.SaveChangesAsync();
            //return Task.FromResult("Processo executado com sucesso.");
        }
    }
}
