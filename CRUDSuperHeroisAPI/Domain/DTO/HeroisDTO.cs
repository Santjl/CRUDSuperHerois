using CRUDSuperHeroisAPI.Domain.Services;
using Newtonsoft.Json;
using System;

namespace CRUDSuperHeroisAPI.Domain.DTO
{
    public class HeroisDTO
    {
        private const string data = "dd/MM/yyyy";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        [JsonConverter(typeof(DateTimeConverterService), data)]
        public DateTime DataNascimento { get; set; }
        public Double Altura { get; set; }
        public Double Peso { get; set; }
        
    }
}
