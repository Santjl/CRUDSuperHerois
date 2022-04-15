using System;

namespace CRUDSuperHeroisAPI.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        void CriarTransacao();

        void CommitComTransacao();

        void RollbackTransacao();
    }
}
