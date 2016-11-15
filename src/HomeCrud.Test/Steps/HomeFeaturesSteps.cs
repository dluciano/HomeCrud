using HomeCrud.Core.Abstract;
using HomeCrud.Core.Request;
using HomeCrud.Core.Response;
using HomeCrud.Test.Specs.Abstract;
using Should;
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
        public void ThenTheFollowingHomeShouldExists(Table table) =>
            table.CompareToInstance(_homeDetails);

        [Given(@"I add a person with the following data to that home")]
        public void GivenIAddAPersonWithTheFollowingDataToThatHome(Table table)
        {
            var request = table.CreateInstance<CreatePersonRequest>();
            request.Home = _container.GetInstance<IListHomeFeature>().Exec().Last().Id;
            var feature = _container.GetInstance<ICreatePersonFeature>();
            feature.Exec(request);
        }

        [Then(@"the person count should be (.*)")]
        public void ThenThePersonCountShouldBe(int count) =>
            _homeDetails.People.Count().ShouldEqual(count);

        [Then(@"the following person data should be displayed")]
        public void ThenTheFollowingPersonDataShouldBeDisplayed(Table table) =>
            table.CompareToSet(_homeDetails.People);

        [Then(@"should exists a home with data")]
        public void LastShouldBeEqulsTo(Table table)
        {
            var listFeature = _container.GetInstance<IListHomeFeature>();
            var entities = listFeature.Exec();
            var last = entities.Last();
            table.CompareToInstance(last);
        }

        [Then(@"the count of homes should be (.*)")]
        public void ThenTheCountOfHomesShouldBe(int count) =>
            _container.GetInstance<IListHomeFeature>().Exec().Count().ShouldEqual(count);

        [Then(@"shouldn't exists people")]
        public void ThenShouldnTExistsPeople() =>
            _container.GetInstance<IPersonListFeature>().Exec().Count().ShouldEqual(0);

        [Then(@"the following homes should exists")]
        public void FollowingHomesShouldExists(Table table) =>
            table.CompareToSet(lastNEntities);

        private IEnumerable<HomeRowResponse> lastNEntities;
        private HomeDetailsResponse _homeDetails;
    }
}