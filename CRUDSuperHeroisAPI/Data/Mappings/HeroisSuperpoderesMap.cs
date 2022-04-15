using CRUDSuperHeroisAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDSuperHeroisAPI.Data.Mappings
{
    public class HeroisSuperpoderesMap : IEntityTypeConfiguration<HeroisSuperpoderes>
    {
        public void Configure(EntityTypeBuilder<HeroisSuperpoderes> builder)
        {
            builder.HasKey(hs => new { hs.HeroiId, hs.SuperpoderId });

            builder.HasOne<Herois>(hs => hs.Herois)
                .WithMany(h => h.HeroisSuperpoderes)
                .HasForeignKey(hs => hs.HeroiId);

            builder.HasOne<Superpoderes>(hs => hs.Superpoderes)
                .WithMany(s => s.HeroisSuperpoderes)
                .HasForeignKey(hs => hs.SuperpoderId);
        }
    }
}
