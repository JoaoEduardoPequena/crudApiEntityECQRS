

namespace Domain.Entities
{
    public class Produto
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public DateTime Criacao { get; set; }
        //public int Id_Categoria { get; set; }
        //public virtual ICollection<Categoria> Categoria { get; set; }
        public int Id_Categoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
