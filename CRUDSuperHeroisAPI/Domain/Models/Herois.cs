using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class Herois
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; private set; }
    
        public Herois() { }
        public Herois(string nome, string nomeHeroi, DateTime dataNascimento,
            double altura, double peso)
        {
            Nome = nome;
            NomeHeroi = nomeHeroi;
            DataNascimento = dataNascimento;
            Altura = altura;  
            Peso = peso;
        }
    
    }
}
