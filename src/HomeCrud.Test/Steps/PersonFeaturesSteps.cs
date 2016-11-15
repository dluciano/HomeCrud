using Should;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class PersonFeaturesSteps : BaseSteps
    {
        private IEnumerable<PersonListRowResponse> _personList;
        private PersonDetailsResponse _personDetail;

        [Given(@"I create one home with the following data")]
        public void CreateHome(Table table)
        {
            var request = table.CreateInstance<CreateHomeRequest>();
            var feature = _container.GetInstance<ICreateHomeFeature>();
            feature.Exec(request);
        }

        [Given(@"I add a person with the following data to the last added home")]
        [When(@"I add a person with the following data to the last added home")]
        public void WhenIAddAPersonWithTheFollowingDataToTheLastAddedHome(Table table)
        {
            var request = table.CreateInstance<CreatePersonRequest>();
            request.Home = _container.GetInstance<IListHomeFeature>().Exec().Last().Id;
            var feature = _container.GetInstance<ICreatePersonFeature>();
            feature.Exec(request);
        }

        [Given(@"I update the last person details with the following data")]
        public void GivenIUpdateTheLastPersonDetailsWithTheFollowingData(Table table)
        {
            var request = table.CreateInstance<UpdatePersonRequest>();
            request.Id = _container.GetInstance<IPersonListFeature>().Exec().Last().Id;
            var updateFeature = _container.GetInstance<IUpdatePersonFeature>();
            updateFeature.Exec(request);
        }

        [When(@"I list the people")]
        public void WhenIListThePeople() =>
            _personList = _container.GetInstance<IPersonListFeature>().Exec();

        [When(@"I access the last person details")]
        public void WhenIAccessTheLastPersonDetails()
        {
            var listFeature = _container.GetInstance<IPersonListFeature>();
            var lastId = listFeature.Exec().Last().Id;
            var detailFeature = _container.GetInstance<IPersonDetailFeature>();
            _personDetail = detailFeature.Exec(lastId);
        }

        [When(@"I delete the last added person")]
        public void WhenIDeleteTheLastAddedPerson()
        {
            var request = new DeletePersonRequest();
            request.PersonId = _container.GetInstance<IPersonListFeature>().Exec().Last().Id;
            var deleteFeature = _container.GetInstance<IDeletePersonFeature>();
            deleteFeature.Exec(request);
        }

        [Then(@"the last home added should contain (.*) person")]
        public void ThenTheLastHomeAddedShouldContainPerson(int count) =>
            _container.GetInstance<IListHomeFeature>().Exec().Last().Persons.ShouldEqual(count);

        [Then(@"the last person data should contain the following data")]
        public void ThenTheLastPersonDataShouldContainTheFollowingData(Table table)
        {
            var lastPerson = _container.GetInstance<IPersonListFeature>().Exec().Last();
            table.CompareToInstance(lastPerson);
            lastPerson.Home.ShouldEqual(_container.GetInstance<IListHomeFeature>().Exec().Last().Name);
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

        [Then(@"should exists the following people")]
        public void ThenShouldExistsTheFollowingPeople(Table table) =>
            table.CompareToSet(_personList);

        [Then(@"the person details should contains the following data")]
        public void ThenThePersonDetailsShouldContainsTheFollowingData(Table table) =>
            table.CompareToInstance(_personDetail);

    }
}
