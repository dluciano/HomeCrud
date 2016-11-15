namespace HomeCrud.Entities
{
    public interface IToEntity<TEntity> 
        where TEntity : IEntity
    {
        TEntity ToEntity();
    }
}