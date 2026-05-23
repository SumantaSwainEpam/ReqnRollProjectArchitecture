using System;
using FluentAssertions;
using Reqnroll;
using ReqnRollProjectArchitecture.Credentials;
using ReqnRollProjectArchitecture.Pages;

namespace ReqnRollProjectArchitecture.StepDefinitions
{
    [Binding]
    public class LoginFunctionalityForSauceDemoApplicationStepDefinitions
    {
        private readonly LogInPage _logInPage;
        public LoginFunctionalityForSauceDemoApplicationStepDefinitions(LogInPage logInPage)
        {
            _logInPage = logInPage;
        }
        [Given("user launches SauceDemo application")]
        public void GivenUserLaunchesSauceDemoApplication()
        {
            _logInPage.NavigateToApplication(CredentialsManager.GetBaseUrl());
        }

        [When("user enters username {string}")]
        public void WhenUserEntersUsername(string p0)
        {
            _logInPage.EnterUserName(p0);
        }

        [When("user enters password {string}")]
        public void WhenUserEntersPassword(string p0)
        {
            _logInPage.EnterPassword(p0);

        }

        [When("user clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            _logInPage.ClickLoginButton();
            
        }

        [Then("user should see {string}")]
        public void ThenUserShouldSee(string expectedResult)
        {
            if (expectedResult.Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                _logInPage.IsAppLogoDisplayed()
                    .Should()
                    .BeTrue("Expected app logo to be displayed after successful login.");

                _logInPage.IsAppLogoTextCorrect(CredentialsManager.GetAppTitle())
                    .Should()
                    .BeTrue($"Expected app logo text to be '{CredentialsManager.GetAppTitle()}', but it was not.");
            }
            else if (expectedResult.Equals("failure", StringComparison.OrdinalIgnoreCase))
            {
                _logInPage.IsErrorMessageDisplayed()
                    .Should()
                    .BeTrue("Expected error message to be displayed for failed login.");
            }
        }
    }

}

    



