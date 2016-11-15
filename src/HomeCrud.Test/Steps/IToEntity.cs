namespace HomeCrud.Test.Specs
{
    public interface IToEntity<TEntity> 
        where TEntity : IEntity
    {
        TEntity ToEntity();
    }
}