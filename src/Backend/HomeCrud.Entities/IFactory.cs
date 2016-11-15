namespace HomeCrud.Entities
{
    public interface IFactory<in TEntity, out TResponse>
        where TEntity : IEntity
    {
        TResponse Create(TEntity entity);
    }
}