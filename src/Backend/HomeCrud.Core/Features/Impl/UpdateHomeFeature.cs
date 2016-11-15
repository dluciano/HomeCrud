using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.DA.Common;
using HomeCrud.Entities;

namespace HomeCrud.Core.Impl
{
    public class UpdateHomeFeature : IUpdateHomeFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IRepository<Home> _repo;

        public UpdateHomeFeature(IRepository<Home> repo,
            IUnitOfWork db)
        {
            _repo = repo;
            _db = db;
        }

        public void Exec(UpdateHomeRequest request)
        {
            request.IFillEntity(_repo.ById(request.Id));
            _db.SaveChanges();
        }
    }
}