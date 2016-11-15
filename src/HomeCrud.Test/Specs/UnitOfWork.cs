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

        public void SaveChanges() =>
            _context.SaveChanges();
    }
}