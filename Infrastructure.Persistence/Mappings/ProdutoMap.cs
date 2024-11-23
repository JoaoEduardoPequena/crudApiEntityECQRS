using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id_Produto);
            builder.Property(p => p.Id_Produto)
                .IsRequired()
                .HasColumnName("Id_Produto")
                .HasColumnType("int");
            builder.Property(p => p.Criacao)
                .HasColumnType("datetime");
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(400)");

            // Configurando o relacionamento um-para-muito entre Produto e Categoria
            builder.HasOne(p => p.Categoria)           // Uma Categoria
                .WithMany(p=>p.Produto)               // tem muitos Produto
                .HasForeignKey(p => p.Id_Categoria); // Chave estrangeira
        }
    }
}
