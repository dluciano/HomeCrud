﻿using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.DA.Common;
using HomeCrud.Entities;

namespace HomeCrud.Core.Impl
{
    public class CreateHomeFeature : ICreateHomeFeature
    {
        private readonly IUnitOfWork _db;
        private readonly IWriteRepository<Home> _repo;

        public CreateHomeFeature(IWriteRepository<Home> repo, IUnitOfWork db)
        {
            _repo = repo;
            _db = db;
        }

        public void Exec(CreateHomeRequest request)
        {
            request.ToEntity().Add(_repo);
            _db.SaveChanges();
        }
    }
}