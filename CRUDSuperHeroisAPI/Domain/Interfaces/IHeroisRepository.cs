using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Models;
using System;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Interfaces
{
    public interface IHeroisRepository : IBaseRepository<Herois>
    {
        IEnumerable<HeroisDTO> BuscarHerois();
        HeroisDTO BuscarHeroiPorId(int heroiId);
        Herois AdicionarHeroi(string nome, string nomeHeroi, DateTime dataNascimento,
            double altura, double peso);
        void DeletarHeroi(int heroiId);
        Herois AtualizarHeroi(int heroiId, string nome, string nomeHeroi,
            double altura, double peso);
    }
}
