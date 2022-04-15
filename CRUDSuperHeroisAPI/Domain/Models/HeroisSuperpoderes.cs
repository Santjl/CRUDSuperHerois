namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public virtual Herois Herois { get; set;}
        public int SuperpoderId { get; set; }
        public virtual Superpoderes Superpoderes { get; set; }
    }
}
