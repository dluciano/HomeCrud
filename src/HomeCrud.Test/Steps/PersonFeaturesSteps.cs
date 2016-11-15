using SimpleInjector;
using System;
using TechTalk.SpecFlow;

namespace HomeCrud.Test.Specs
{
    [Binding]
    public class PersonFeaturesSteps
    {
        private readonly Scope _container = new ModuleManager().Container.BeginLifetimeScope();

        [Given(@"I create one home with the following data")]
        public void CreateHome(Table table)
        {
            
        }

        [When(@"I add a person to the last added home, with the following data")]
        public void AddPersonToLastHome(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the last person created should contain the following data")]
        public void ThenTheLastPersonCreatedShouldContainTheFollowingData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the last home created should contain a person with id '(.*)'")]
        public void ThenTheLastHomeCreatedShouldContainAPersonWithId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
