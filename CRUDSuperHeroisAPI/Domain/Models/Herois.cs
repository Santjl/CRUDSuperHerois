using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class Herois
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string NomeHeroi { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Double Altura { get; private set; }
        public Double Peso { get; private set; }
        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; private set; }
    }
}
