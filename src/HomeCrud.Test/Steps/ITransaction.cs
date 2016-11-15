using System;

namespace HomeCrud.Test.Specs
{
    public interface ITransaction : IDisposable
    {
        void Rollback();
    }
}