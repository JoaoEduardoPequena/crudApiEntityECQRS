namespace Domain.Entities
{
    public  class Categoria
    {
        public int Id_Categoria { get; set; }
        public string Nome { get; set; }
        //public int Id_Produto { get; set; }
        //public Produto Produto { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
