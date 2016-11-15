using HomeCrud.Core.Abstract;
using HomeCrud.Core.Impl;
using HomeCrud.DA.Common;
using HomeCrud.DA.EntityFramework;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using System.Data.Entity;

namespace HomeCrud.Modules
{
    public class ModuleManager
    {
        public Container Container { get; } = new Container();

        public ModuleManager(ScopedLifestyle scope = null)
        {
            Container.Options.DefaultScopedLifestyle = scope ?? new LifetimeScopeLifestyle();

            Container.Register<DbContext, DataBaseContext>(Lifestyle.Scoped);
            Container.Register(typeof(IDataSource<>), typeof(EntityFrameworkDataSource<>), Lifestyle.Scoped);
            Container.Register(typeof(IWriteRepository<>), typeof(WriteRepository<>), Lifestyle.Scoped);
            Container.Register(typeof(IReadRepository<>), typeof(ReadRepository<>), Lifestyle.Scoped);
            Container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            Container.Register<IUnitOfWork, EntityFrameworkUnitOfWork>(Lifestyle.Scoped);
            Container.Register<ICreateHomeFeature, CreateHomeFeature>(Lifestyle.Scoped);
            Container.Register<IListHomeFeature, ListHomeFeature>(Lifestyle.Scoped);
            Container.Register<IHomeDetailsFeature, HomeDetailsFeature>(Lifestyle.Scoped);
            Container.Register<IUpdateHomeFeature, UpdateHomeFeature>(Lifestyle.Scoped);
            Container.Register<IDeleteHomeFeature, DeleteHomeFeature>(Lifestyle.Scoped);
            Container.Register<ICreatePersonFeature, CreatePersonFeature>(Lifestyle.Scoped);
            Container.Register<IPersonListFeature, PersonListFeature>(Lifestyle.Scoped);
            Container.Register<IPersonDetailFeature, PersonDetailFeature>(Lifestyle.Scoped);
            Container.Register<IUpdatePersonFeature, UpdatePersonFeature>(Lifestyle.Scoped);
            Container.Register<IDeletePersonFeature, DeletePersonFeature>(Lifestyle.Scoped);
        }
    }
}