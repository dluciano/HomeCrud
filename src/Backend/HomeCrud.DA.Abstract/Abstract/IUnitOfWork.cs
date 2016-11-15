namespace HomeCrud.DA.Common
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        ITransaction BeginTrans();
    }
}