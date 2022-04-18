using System;

namespace CRUDSuperHeroisAPI.Domain.InputModels
{
    public class AtualizarHerois
    {
        public int HeroiId { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura  { get; set; }
        public double Peso { get; set; }
    }
}
