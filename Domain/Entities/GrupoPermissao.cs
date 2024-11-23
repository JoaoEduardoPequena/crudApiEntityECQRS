
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("GruposPermissoes", Schema = "Identity")]
    public class GrupoPermissao
    { 
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGrupoPermissao { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
