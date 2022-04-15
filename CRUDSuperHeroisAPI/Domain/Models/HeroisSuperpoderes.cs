namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; private set; }
        public virtual Herois Herois { get; private set; }
        public int SuperpoderId { get; private set; }
        public virtual Superpoderes Superpoderes { get; private set; }
    }
}
