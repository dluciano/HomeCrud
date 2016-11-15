using System;
using System.Data.Entity;

namespace HomeCrud.Test.Specs
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EntityFrameworkUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public ITransaction BeginTrans() =>
            new Transaction(_context.Database.BeginTransaction());

        public void SaveChanges() =>
            _context.SaveChanges();

        public class Transaction : ITransaction
        {
            private DbContextTransaction _dbTrans;

            public Transaction(DbContextTransaction dbTrans)
            {
                _dbTrans = dbTrans;
            }

            public virtual void Commit() =>
                _dbTrans.Commit();

            public void Dispose() =>
                _dbTrans.Dispose();

            public void Rollback() =>
                _dbTrans.Rollback();
        }
    }
}