using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Models;

namespace CRUDSuperHeroisAPI.Domain.Interfaces
{
    public interface IHeroisSuperpoderesRepository : IBaseRepository<HeroisSuperpoderes>
    {
        void AssociarHeroiSuperpoder(int heroiId, int superpoderId);
        void DesassociarHeroiSuperpoder(int heroidId, int superpoderId);
        HeroisSuperpoderesDTO BuscarHeroisSuperpoder(int heroiId);
    }
}
