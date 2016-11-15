using HomeCrud.DA.Common;
using HomeCrud.Entities;
using System.Linq;

namespace HomeCrud.Core
{
    public static class RepositoryExtensions
    {
        public static TEntity ById<TEntity>(this IReadRepository<TEntity> repo, int id)
            where TEntity : class, IEntity =>
            repo.Single(e => e.Id == id);

        public static void Add<TEntity>(this TEntity entity, IWriteRepository<TEntity> repo)
            where TEntity : IEntity =>
            repo.Add(entity);
    }
}
