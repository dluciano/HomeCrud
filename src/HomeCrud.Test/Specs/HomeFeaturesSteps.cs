using SimpleInjector;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class HomeFeaturesSteps : IDisposable
    {
        private readonly Scope _container = new ModuleManager().Container.BeginLifetimeScope();

        [When(@"I create a home with the following data")]
        public void CreateHome(Table table)
        {
            var request = table.CreateInstance<CreateHomeRequest>();
            var feature = _container.GetInstance<ICreateHomeFeature>();
            feature.Exec(request);
        }


        [Then(@"should exists a home with data")]
        public void ThenShouldExistsAHomeWithData(Table table)
        {
            table.CreateInstance<Home>();
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _container.Dispose();
                GC.Collect();
            }
        }
    }
}
