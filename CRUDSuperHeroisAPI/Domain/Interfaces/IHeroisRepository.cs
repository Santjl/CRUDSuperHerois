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
        HeroisDTO AtualizarHeroi(int heroiId, string nome, DateTime dataNascimento, string nomeHeroi,
            double altura, double peso);
        HeroisDTO BuscarHeroiPorNomeHeroi(string nome);
        HeroisDTO BuscarHeroiPorNome(string nome);
    }
}
