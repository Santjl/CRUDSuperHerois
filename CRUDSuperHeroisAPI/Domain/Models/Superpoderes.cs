using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class Superpoderes
    {
        public int Id { get; private set; }
        public string Superpoder { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; private set; }

        public Superpoderes(string superpoder, string descricao)
        {
            Superpoder = superpoder;
            Descricao = descricao;
        }
    }
}
