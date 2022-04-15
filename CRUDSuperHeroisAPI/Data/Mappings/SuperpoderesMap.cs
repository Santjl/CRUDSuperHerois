using CRUDSuperHeroisAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDSuperHeroisAPI.Data.Mappings
{
    public class SuperpoderesMap : IEntityTypeConfiguration<Superpoderes>
    {
        public void Configure(EntityTypeBuilder<Superpoderes> builder)
        {
            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.HasKey("Id");

            builder.Property(s => s.Superpoder)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(s => s.Descricao)
                .HasColumnType("nvarchar(250)")
                .IsRequired();
        }
    }
}
