using SimpleInjector;
using System;
using System.Linq;
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
            var listFeature = _container.GetInstance<IListHomeFeature>();
            var entities = listFeature.Exec();
            var last = entities.Last();
            table.CompareToInstance(last);
        }

        void IDisposable.Dispose() =>
            Dispose(true);

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
