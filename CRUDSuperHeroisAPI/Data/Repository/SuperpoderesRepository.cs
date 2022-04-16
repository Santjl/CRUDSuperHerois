using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUDSuperHeroisAPI.Data.Repository
{
    public class SuperpoderesRepository : BaseRepository<Superpoderes>, ISuperpoderesRepository
    {
        public SuperpoderesRepository(SuperHeroisContext context) : base(context)
        {

        }

        public IEnumerable<SuperpoderesDTO> BuscarSuperpoderes()
        {
            var superpoderes = Db.Superpoderes
                .Select(s => new SuperpoderesDTO
                {
                    Id = s.Id,
                    Superpoder = s.Superpoder,
                    Descricao = s.Descricao,
                });

            return superpoderes;
        }

        public SuperpoderesDTO BuscarSuperpoder(int id)
        {
            var superpoder = Db.Superpoderes.Where(s => s.Id == id).Select(s => new SuperpoderesDTO
            {
                Id = s.Id,
                Superpoder = s.Superpoder,
                Descricao = s.Descricao,
            }).FirstOrDefault();

            return superpoder;

        }

        public void DeletarSuperpoder(int id)
        {
            var superpoder = Db.Superpoderes.Where(s => s.Id == id).FirstOrDefault();
            Db.Superpoderes.Remove(superpoder);
            SaveChanges();
        }

        public void AdicionarSuperpoder(string superpoder, string descricao)
        {
            var novoSuperpoder = new Superpoderes(superpoder, descricao);
            Add(novoSuperpoder);
            SaveChanges();
        }
    }
}
