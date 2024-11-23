

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id_Categoria);
            builder.Property(c=>c.Id_Categoria)
            .HasColumnName("Id_Categoria")
            .HasColumnType("int");

            builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(400)");
        }
    }
}
