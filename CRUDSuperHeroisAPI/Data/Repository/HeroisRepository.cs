using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CRUDSuperHeroisAPI.Data.Repository
{
    public class HeroisRepository : BaseRepository<Herois>, IHeroisRepository
    {
        public HeroisRepository(SuperHeroisContext context) : base(context)
        {

        }

        public IEnumerable<HeroisDTO> BuscarHerois()
        {
            var herois = Db.Herois.Select(h => new HeroisDTO
            {
                Id = h.Id,
                Nome = h.Nome,
                NomeHeroi = h.NomeHeroi,
                DataNascimento = h.DataNascimento,
                Altura = h.Altura,
                Peso = h.Peso,
            });
            return herois;
        } 

        public HeroisDTO BuscarHeroiPorId(int heroiId)
        {
            var heroi = Db.Herois
                .Where(h => h.Id == heroiId)
                .Select(h => new HeroisDTO
                {
                    Id = h.Id,
                    Nome = h.Nome,
                    NomeHeroi = h.NomeHeroi,
                    DataNascimento = h.DataNascimento,
                    Altura = h.Altura,
                    Peso = h.Peso,
                }).FirstOrDefault();
                            
            return heroi;
        }

        public Herois AdicionarHeroi(string nome, string nomeHeroi, DateTime dataNascimento, 
            Double altura, Double peso)
        {
            var novoHeroi = new Herois(nome, nomeHeroi, dataNascimento, altura, peso);

            Add(novoHeroi);
            SaveChanges();

            return novoHeroi;
        }

        public void DeletarHeroi(int heroiId)
        {
            var heroi = Db.Herois.Where(h => h.Id == heroiId).FirstOrDefault();
            Db.Herois.Remove(heroi);
            SaveChanges();

        }

        public Herois AtualizarHeroi(int heroiId, string nome, string nomeHeroi,
            double altura, double peso)
        {
            var heroi = Db.Herois.Where(h => h.Id == heroiId).FirstOrDefault();

            if (nome != "") heroi.Nome = nome;
            if(nomeHeroi != "") heroi.NomeHeroi = nomeHeroi;
            if(altura != 0) heroi.Altura = (double)altura;
            if(peso != 0) heroi.Peso = (double)peso;

            SaveChanges();

            return Db.Herois.Where(h => h.Id == heroiId).FirstOrDefault();

        }

    }
}
