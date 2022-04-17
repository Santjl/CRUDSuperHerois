using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class Superpoderes
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; private set; }

        public Superpoderes(string superpoder, string descricao)
        {
            Superpoder = superpoder;
            Descricao = descricao;
        }
    }
}
