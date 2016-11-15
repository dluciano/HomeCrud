using Should;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class PersonFeaturesSteps : BaseSteps
    {
        [Given(@"I create one home with the following data")]
        public void CreateHome(Table table)
        {
            var request = table.CreateInstance<CreateHomeRequest>();
            var feature = _container.GetInstance<ICreateHomeFeature>();
            feature.Exec(request);
        }

        [When(@"I add a person with the following data to the last added home")]
        public void WhenIAddAPersonWithTheFollowingDataToTheLastAddedHome(Table table)
        {
            var request = table.CreateInstance<CreatePersonRequest>();
            request.Home = _container.GetInstance<IListHomeFeature>().Exec().Last().Id;
            var feature = _container.GetInstance<ICreatePersonFeature>();
            feature.Exec(request);
        }

        [Then(@"the last person created should contain the following data")]
        public void ThenTheLastPersonCreatedShouldContainTheFollowingData(Table table)
        {
            var listFeature = _container.GetInstance<IPersonListFeature>();
            var lastId = listFeature.Exec().Last().Id;
            var detailFeature = _container.GetInstance<IPersonDetailFeature>();
            var e = detailFeature.Exec(lastId);
            table.CompareToInstance(e);
        }

        [Then(@"the last home created should contain (.*) person with id '(.*)'")]
        public void HomeShouldContainOnePersonWithId(int count, string id)
        {
            var listFeature = _container.GetInstance<IListHomeFeature>();
            listFeature.Exec().Last().Persons.ShouldEqual(count);
        }
    }
}
