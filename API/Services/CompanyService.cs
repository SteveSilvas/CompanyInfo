using CompanyInfo.DTOs;
using CompanyInfo.Enuns;
using CompanyInfo.Functions;
using CompanyInfo.Interfaces;
using CompanyInfo.Models;

namespace CompanyInfo.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGetCompanyInfo _getCompanyInfo;
        private readonly ICompanyRepository _companyRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityXCompanyRepository _activityXCompanyRepository;
        private readonly IQsaRepository _qsaRepository;
        public CompanyService(
            ICompanyRepository companyRepository,
            IGetCompanyInfo getCompanyInfo,
            IActivityRepository activityRepository,
            IActivityXCompanyRepository activityXCompanyRepository,
            IQsaRepository qsaRepository)
        {
            _getCompanyInfo = getCompanyInfo;
            _companyRepository = companyRepository;
            _activityRepository = activityRepository;
            _activityXCompanyRepository = activityXCompanyRepository;
            _qsaRepository = qsaRepository;
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

        public async Task Create(CompanyInfoDTO companyInfoDTO)
        {
            companyInfoDTO.CNPJ = Helpers.CleanCNPJ(companyInfoDTO.CNPJ);

            if (!CNPJValidator.IsValid(companyInfoDTO.CNPJ))
                throw new Exception("CNPJ inválido.");

            if (IsExitentingCNPJ(companyInfoDTO.CNPJ))
                throw new Exception("CNPJ já existente.");

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
                CapitalSocial = companyInfoDTO.CapitalSocial,
                BillingFree = companyInfoDTO.Billing.Free,
                BillingDatabase = companyInfoDTO.Billing.Database,
            };

            int companyId = await _companyRepository.Create(company);

            GenerateMainActivities(companyInfoDTO.AtividadePrincipal, companyId);
            GenerateSecundaryActivities(companyInfoDTO.AtividadesSecundarias, companyId);
            GenerateQsas(companyInfoDTO.QSA, companyId);
        }

        private bool IsExitentingCNPJ(string cNPJ)
        {
            Empresa? empresa = _companyRepository.GetByCNPJ(cNPJ);

            return empresa != null;
        }

        private async void GenerateMainActivities(List<AtividadeDTO>? mainActivities, int companyId)
        {
            if (mainActivities == null || mainActivities.Count == 0) return;

            foreach (AtividadeDTO mainActivity in mainActivities)
            {
                Atividade activity = new Atividade
                {
                    Code = mainActivity.Code,
                    Text = mainActivity.Text
                };

                int activityId = await _activityRepository.Create(activity);

                GenerateActivityXCompany(activityId, companyId, (int)TipoAtividade.Principal);
            }
        }

        private void GenerateActivityXCompany(int activityId, int companyId, int activityType)
        {
            AtividadeXEmpresa activityXCompany = new AtividadeXEmpresa
            {
                IdAtividade = activityId,
                IdEmpresa = companyId,
                Tipo = activityType
            };

            _activityXCompanyRepository.Create(activityXCompany);
        }

        private async void GenerateSecundaryActivities(List<AtividadeDTO>? secundaryActivities, int companyId)
        {
            if (secundaryActivities == null || secundaryActivities.Count == 0) return;

            foreach (AtividadeDTO secundaryActivity in secundaryActivities)
            {
                Atividade activity = new Atividade
                {
                    Code = secundaryActivity.Code,
                    Text = secundaryActivity.Text
                };

                int activityId = await _activityRepository.Create(activity);

                GenerateActivityXCompany(activityId, companyId, (int)TipoAtividade.Secundaria);
            }
        }

        private void GenerateQsas(List<QsaDTO> qsas, int companyId)
        {
            foreach(QsaDTO qsa in qsas)
            {
                Qsa qsaOfCompany = new Qsa
                {
                    IdEmpresa = companyId,
                    Nome = qsa.Nome,
                };
                SaveQsa(qsaOfCompany);
            }
        }

        private void SaveQsa(Qsa qsaOfCompany)
        {
            _qsaRepository.Create(qsaOfCompany);
        }
    }
}
