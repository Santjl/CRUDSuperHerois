using CRUDSuperHeroisAPI.Domain.DTO;
using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.InputModels
{
    public class AtualizarHeroiSuperpoderes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<SuperpoderesDTO> Superpoderes { get; set; }
    }
}
