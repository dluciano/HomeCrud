using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using System.Data.Entity;

namespace HomeCrud.Test.Specs
{
    public class ModuleManager
    {
        public Container Container { get; } = new Container();

        public ModuleManager()
        {
            Container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
            Container.Register<DbContext, DataBaseContext>(Lifestyle.Scoped);
            Container.Register(typeof(IDataSource<>), typeof(EntityFrameworkDataSource<>), Lifestyle.Scoped);
            Container.Register(typeof(IWriteRepository<>), typeof(WriteRepository<>), Lifestyle.Scoped);
            Container.Register(typeof(IReadRepository<>), typeof(ReadRepository<>), Lifestyle.Scoped);
            Container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            Container.Register<IUnitOfWork, EntityFrameworkUnitOfWork>(Lifestyle.Scoped);
            Container.Register<ICreateHomeFeature, CreateHomeFeature>(Lifestyle.Scoped);
            Container.Register<IListHomeFeature, ListHomeFeature>(Lifestyle.Scoped);
            Container.Register<IUpdateHomeFeature, UpdateHomeFeature>(Lifestyle.Scoped);
            Container.Register<IDeleteHomeFeature, DeleteHomeFeature>(Lifestyle.Scoped);
        }
    }
}