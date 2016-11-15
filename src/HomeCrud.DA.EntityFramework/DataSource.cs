using HomeCrud.DA.Common;
using HomeCrud.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HomeCrud.Test.Specs
{
    public class EntityFrameworkDataSource<TEntity> :
        IDataSource<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbSet<TEntity> efDataSet;

        public EntityFrameworkDataSource(DbContext context)
        {
            efDataSet = context.Set<TEntity>();
        }

        public Type ElementType => efDataSet.ElementType;

        public Expression Expression => efDataSet.Expression;

        public IQueryProvider Provider => efDataSet.Provider;

        public void Add(TEntity entity) => efDataSet.Add(entity);

        public void Delete(int id) => efDataSet.Remove(efDataSet.Single(e => e.Id == id));

        public IEnumerator<TEntity> GetEnumerator() => efDataSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}