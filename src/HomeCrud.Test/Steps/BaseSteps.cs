using SimpleInjector;
using System;
using TechTalk.SpecFlow;

namespace HomeCrud.Test.Specs
{
    public abstract class BaseSteps : IDisposable
    {
        protected readonly Scope _container = new ModuleManager().Container.BeginLifetimeScope();
        protected ITransaction _trans;

        [BeforeScenario()]
        public void BeginTransaction() =>
            _trans = _container.GetInstance<IUnitOfWork>().BeginTrans();

        [AfterScenario()]
        public void Rollback() =>
            _trans.Rollback();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _trans.Dispose();
                _container.Dispose();
            }
        }
    }
}