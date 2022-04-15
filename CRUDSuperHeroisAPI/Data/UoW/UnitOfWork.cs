using CRUDSuperHeroisAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CRUDSuperHeroisAPI.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuperHeroisContext _context;
        private IDbContextTransaction _transactionScope;

        public UnitOfWork(SuperHeroisContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void CommitComTransacao()
        {
            if (_transactionScope == null)
            {
                throw new InvalidOperationException("Não existe nenhuma transação aberta no momento.");
            }

            _context.SaveChanges();
            _transactionScope.Commit();
            _transactionScope.Dispose();
            _transactionScope = null;
        }

        public void CriarTransacao()
        {
            _transactionScope = _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollbackTransacao()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Rollback();
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }
    }
}
