using HomeCrud.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HomeCrud.DA.Common
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDataSource<TEntity> _dataSource;

        public ReadRepository(IDataSource<TEntity> dataSource)
        {
            _dataSource = dataSource;
        }

        public Type ElementType => _dataSource.ElementType;

        public Expression Expression => _dataSource.Expression;

        public IQueryProvider Provider => _dataSource.Provider;

        public IEnumerator<TEntity> GetEnumerator() => _dataSource.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}