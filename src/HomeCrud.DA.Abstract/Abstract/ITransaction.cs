using System;

namespace HomeCrud.DA.Common
{
    public interface ITransaction : IDisposable
    {
        void Rollback();
        void Commit();
    }
}