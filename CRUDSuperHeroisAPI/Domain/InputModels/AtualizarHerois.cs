using System;

namespace CRUDSuperHeroisAPI.Domain.InputModels
{
    public class AtualizarHerois
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public double Altura  { get; set; }
        public double Peso { get; set; }
    }
}
