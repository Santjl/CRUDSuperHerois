using Microsoft.EntityFrameworkCore;
using System.Linq;
using CRUDSuperHeroisAPI.Domain.Models;


namespace CRUDSuperHeroisAPI.Data
{
    public class SuperHeroisContext : DbContext
    {
        public SuperHeroisContext(DbContextOptions<SuperHeroisContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
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
