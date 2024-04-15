using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyInfo.Models
{
    public class Qsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public int IdEmpresa { get; set; }
        public virtual Empresa? Empresa { get; set; }
    }
}
