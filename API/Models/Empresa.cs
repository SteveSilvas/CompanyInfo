using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyInfo.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Abertura { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Fantasia { get; set; } = string.Empty;
        public string Porte { get; set; } = string.Empty;
        public string NaturezaJuridica { get; set; } = string.Empty;
        //public List<Atividade> AtividadePrincipal { get; set; }
        //public List<Atividade> AtividadesSecundarias { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string DataSituacao { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public DateTime UltimaAtualizacao { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EFR { get; set; } = string.Empty;
        public string MotivoSituacao { get; set; } = string.Empty;
        public string SituacaoEspecial { get; set; } = string.Empty;
        public string DataSituacaoEspecial { get; set; } = string.Empty;
        public string CapitalSocial { get; set; } = string.Empty;
        //public List<Qsa> QSA { get; set; }
        //public Dictionary<string, string> Extra { get; set; }
        //public int BillingId { get; set; }
        //public virtual Billing Billing { get; set; }
    }
}
