using CRUDSuperHeroisAPI.Domain.DTO;
using CRUDSuperHeroisAPI.Domain.Models;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Interfaces
{
    public interface ISuperpoderesRepository : IBaseRepository<Superpoderes>
    {
        IEnumerable<SuperpoderesDTO> BuscarSuperpoderes();
        SuperpoderesDTO BuscarSuperpoder(int id);
        void DeletarSuperpoder(int id);
        Superpoderes AdicionarSuperpoder(string superpoder, string descricao);
        SuperpoderesDTO BuscarSuperpoderPorNome(string nome);
    }
}
