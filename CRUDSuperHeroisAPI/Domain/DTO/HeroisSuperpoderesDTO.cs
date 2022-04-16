using CRUDSuperHeroisAPI.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.DTO
{
    public class HeroisSuperpoderesDTO
    {
        private const string data = "dd/MM/yyyy";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        [JsonConverter(typeof(DateTimeConverterService), data)]
        public DateTime DataNascimento { get; set; }
        public Double Altura { get; set; }
        public Double Peso { get; set; }
        public List<SuperpoderesDTO> Superpoderes {get; set;}
    }
}
