using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HomeCrud.Test.Specs
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbSet<TEntity> _dbSet;

        public ReadRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public Type ElementType => _dbSet.ElementType;

        public Expression Expression => _dbSet.Expression;

        public IQueryProvider Provider => _dbSet.Provider;

        public IEnumerator<TEntity> GetEnumerator() => _dbSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}