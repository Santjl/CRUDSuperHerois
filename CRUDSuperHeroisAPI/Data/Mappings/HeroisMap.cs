using CRUDSuperHeroisAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDSuperHeroisAPI.Data.Mappings
{
    public class HeroisMap : IEntityTypeConfiguration<Herois>
    {
        public void Configure(EntityTypeBuilder<Herois> builder)
        {
            builder.Property(h => h.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.HasKey("Id");

            builder.Property(h => h.Nome)
                .HasColumnType("nvarchar(120)")
                .IsRequired();

            builder.Property(h => h.NomeHeroi)
                .HasColumnType("nvarchar(120)")
                .IsRequired();
            
            builder.Property(h => h.DataNascimento)
                .HasColumnType("datetime")
                .IsRequired();
            
            builder.Property(h => h.Altura)
                .HasColumnType("float")
                .IsRequired();
            
            builder.Property(h => h.Peso)
                .HasColumnType("float")
                .IsRequired();

            
        }
    }
}
