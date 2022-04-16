using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.InputModels
{
    public class AssociarHeroiSuperpoderes
    {
        public int HeroiId { get; set; }
        public List<int> SuperpoderesId { get; set; }
    }
}
