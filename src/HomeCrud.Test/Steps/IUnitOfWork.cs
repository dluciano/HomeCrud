namespace HomeCrud.Test.Specs
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        ITransaction BeginTrans();
    }
}