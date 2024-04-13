using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfo.Models
{
    public class AtividadeXEmpresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAtividade { get; set; }
        public Atividade? Atividade { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa? Empresa { get; set; }
        public int Tipo { get; set; }
    }
}
