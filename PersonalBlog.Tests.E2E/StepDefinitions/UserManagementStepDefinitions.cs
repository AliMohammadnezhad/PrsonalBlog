using System;
using TechTalk.SpecFlow;

namespace PersonalBlog.Tests.E2E.StepDefinitions
{
    [Binding]
    public class UserManagementStepDefinitions
    {
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            throw new NotImplementedException();
        }

        [When(@"I click on the Sign Up link")]
        public void WhenIClickOnTheSignUpLink()
        {
            throw new NotImplementedException();

        }

        [Then(@"I should be taken to the registration page")]
        public void ThenIShouldBeTakenToTheRegistrationPage()
        {
            throw new NotImplementedException();
        }

        [Then(@"I should see a form to enter my email and password")]
        public void ThenIShouldSeeAFormToEnterMyEmailAndPassword()
        {
            throw new NotImplementedException();
        }

        [When(@"I fill out the form and click '([^']*)'")]
        public void WhenIFillOutTheFormAndClick(string submit)
        {
            throw new NotImplementedException();
        }

        [Then(@"I should receive an email to confirm my account")]
        public void ThenIShouldReceiveAnEmailToConfirmMyAccount()
        {
            throw new NotImplementedException();
        }

        [Then(@"I should be redirected to the login page")]
        public void ThenIShouldBeRedirectedToTheLoginPage()
        {
            throw new NotImplementedException();
        }

        [Given(@"I have a registered account")]
        public void GivenIHaveARegisteredAccount()
        {
            throw new NotImplementedException();
        }

        [When(@"I click on the Submit link")]
        public void WhenIClickOnTheSubmitLink()
        {
            throw new NotImplementedException();
        }

        [Then(@"I should be taken to the login page")]
        public void ThenIShouldBeTakenToTheLoginPage()
        {
            throw new NotImplementedException();
        }

        [Then(@"I should be logged in to the website")]
        public void ThenIShouldBeLoggedInToTheWebsite()
        {
            throw new NotImplementedException();
        }

        [Then(@"I should be redirected to my personalized dashboard")]
        public void ThenIShouldBeRedirectedToMyPersonalizedDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
