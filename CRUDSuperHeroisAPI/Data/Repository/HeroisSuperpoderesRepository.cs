using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Models;
using System.Linq;

namespace CRUDSuperHeroisAPI.Data.Repository
{
    public class HeroisSuperpoderesRepository : BaseRepository<HeroisSuperpoderes>, IHeroisSuperpoderesRepository
    {
        public HeroisSuperpoderesRepository(SuperHeroisContext context) : base(context)
        {

        }

        public void AssociarHeroiSuperpoder(int heroiId, int superpoderId)
        {
            var heroiSupepoder = new HeroisSuperpoderes(heroiId, superpoderId);
            Add(heroiSupepoder);
            SaveChanges();
        }

        public void DesassociarHeroiSuperpoder(int heroidId, int superpoderId)
        {
            var heroiSuperpoder = Db.HeroisSuperpoderes
                .Where(x => x.HeroiId == heroidId 
                && x.SuperpoderId == superpoderId
                ).FirstOrDefault();

            Db.HeroisSuperpoderes.Remove(heroiSuperpoder);
            SaveChanges();
        }

        public HeroisSuperpoderesDTO BuscarHeroisSuperpoder(int heroiId)
        {
            var heroiSuperpoder = Db.HeroisSuperpoderes
                .Where(x => x.HeroiId == heroiId)
                .Select(x => new HeroisSuperpoderesDTO
                {
                    Id = x.HeroiId,
                    Nome = x.Herois.Nome,
                    Altura = x.Herois.Altura,
                    DataNascimento = x.Herois.DataNascimento,
                    NomeHeroi = x.Herois.NomeHeroi,
                    Peso = x.Herois.Peso,
                    Superpoderes = Db.HeroisSuperpoderes
                    .Where( x => x.HeroiId == heroiId)
                    .Select(x => new SuperpoderesDTO
                    {
                        Id = x.Superpoderes.Id,
                        Superpoder = x.Superpoderes.Superpoder,
                        Descricao = x.Superpoderes.Descricao
                    }).ToList()
                }).FirstOrDefault();

            return heroiSuperpoder;
        }
    }
}
