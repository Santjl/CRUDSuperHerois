using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUDSuperHeroisAPI.Data
{
    public class SuperHeroisContext : DbContext
    {
        public SuperHeroisContext(DbContextOptions<SuperHeroisContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);

            foreach (var FK in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                FK.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
