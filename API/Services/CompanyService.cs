using CompanyInfo.DTOs;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;
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

            return _companyRepository.Create(company);
        }
    }
}
