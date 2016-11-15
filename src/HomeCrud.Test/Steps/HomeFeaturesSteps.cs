using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class HomeFeaturesSteps : BaseSteps
    {
        [Given(@"I create a home with the following data")]
        [When(@"I create a home with the following data")]
        public void CreateHome(Table table)
        {
            var request = table.CreateInstance<CreateHomeRequest>();
            var feature = _container.GetInstance<ICreateHomeFeature>();
            feature.Exec(request);
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

        [When(@"I access the details of the last created home")]
        public void AccessDetails()
        {
            var request = new HomeDetailsRequest();
            var entities = _container.GetInstance<IListHomeFeature>().Exec();
            request.Id = entities.Last().Id;
            _homeDetails = _container.GetInstance<IHomeDetailsFeature>().Exec(request);
        }

        [When(@"I list the last (.*) created homes")]
        public void WhenIListTheLastCreatedHomes(int count)
        {
            var listFeature = _container.GetInstance<IListHomeFeature>();
            var entities = listFeature.Exec();
            lastNEntities = entities.Skip(entities.Count() - count);
        }

        [When(@"I delete the last home")]
        public void WhenIDeleteTheLastHome()
        {
            var request = new DeleteHomeRequest();
            var entities = _container.GetInstance<IListHomeFeature>().Exec();
            request.Id = entities.Last().Id;
            var feature = _container.GetInstance<IDeleteHomeFeature>();
            feature.Exec(request);
        }

        [Then(@"the following home should exists")]
        public void ThenTheFollowingHomeShouldExists(Table table)
        {
            table.CompareToInstance(_homeDetails);
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

        private IEnumerable<HomeRowResponse> lastNEntities;
        private HomeDetailsResponse _homeDetails;
    }
}