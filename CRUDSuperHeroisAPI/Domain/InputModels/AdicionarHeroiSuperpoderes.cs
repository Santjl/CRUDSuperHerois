using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.InputModels
{
    public class AdicionarHeroiSuperpoderes
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<AdicionarSuperpoder> Superpoderes { get; set; }
    }
}
