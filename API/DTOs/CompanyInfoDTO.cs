using CompanyInfo.Interfaces;

namespace CompanyInfo.DTOs
{
    public class CompanyInfoDTO 
    {
        public string Abertura { get; set; }
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Porte { get; set; }
        public string NaturezaJuridica { get; set; }
        public List<AtividadeDTO> AtividadePrincipal { get; set; }
        public List<AtividadeDTO> AtividadesSecundarias { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string DataSituacao { get; set; }
        public string CNPJ { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string EFR { get; set; }
        public string MotivoSituacao { get; set; }
        public string SituacaoEspecial { get; set; }
        public string DataSituacaoEspecial { get; set; }
        public string CapitalSocial { get; set; }
        public List<QsaDTO> QSA { get; set; }
        public Dictionary<string, string> Extra { get; set; }
        public BillingDTO Billing { get; set; }
    }
    public class AtividadeDTO
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }

    public class QsaDTO
    {
        // Defina as propriedades conforme necessário para representar os dados QSA
    }

    public class BillingDTO
    {
        public bool Free { get; set; }
        public bool Database { get; set; }
    }
}
