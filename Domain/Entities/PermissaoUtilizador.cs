using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("PermissoesUtilizadores", Schema = "Identity")]
    public class PermissaoUtilizador
    {
        [Key]
        public Guid IdPermissaoUtilizador { get; set; }
        public int IdPermissao { get; set; }

        [ForeignKey("IdPermissao")]
        public virtual Permissao Permissao { get; set; }
        public string IdUtilizador { get; set; }

        [ForeignKey("IdUtilizador")]
        public virtual ApplicationUser Utilizador { get; set; }
    }
}
