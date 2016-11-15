using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class HomeFeaturesSteps : IDisposable
    {
        private readonly Scope _container = new ModuleManager().Container.BeginLifetimeScope();
        private IEnumerable<Home> lastNEntities;

        [Given(@"I create a home with the following data")]
        [When(@"I create a home with the following data")]
        public void CreateHome(Table table)
        {
            var request = table.CreateInstance<CreateHomeRequest>();
            var feature = _container.GetInstance<ICreateHomeFeature>();
            feature.Exec(request);
        }

        [When(@"I list the last (.*) created homes")]
        public void WhenIListTheLastCreatedHomes(int count)
        {
            var listFeature = _container.GetInstance<IListHomeFeature>();
            var entities = listFeature.Exec();
            lastNEntities = entities.Skip(entities.Count() - count);
        }

        [Given(@"I update the last home created with the following data")]
        public void UpdateScenario(Table table)
        {
            var request = table.CreateInstance<UpdateHomeRequest>();
            var entities = _container.GetInstance<IListHomeFeature>().Exec();
            request.Id = entities.Last().Id;
            var feature = _container.GetInstance<IUpdateHomeFeature>();
            feature.Exec(request);
        }

        [Then(@"should exists a home with data")]
        public void LastShouldBeEqulsTo(Table table)
        {
            var listFeature = _container.GetInstance<IListHomeFeature>();
            var entities = listFeature.Exec();
            var last = entities.Last();
            table.CompareToInstance(last);
        }

        [Then(@"the following homes should exists")]
        public void FollowingHomesShouldExists(Table table) =>
            table.CompareToSet(lastNEntities);

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
