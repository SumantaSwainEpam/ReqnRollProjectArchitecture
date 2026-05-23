using System;
using FluentAssertions;
using NUnit.Framework;
using Reqnroll;
using ReqnRollProjectArchitecture.Credentials;
using ReqnRollProjectArchitecture.Pages;

namespace ReqnRollProjectArchitecture.StepDefinitions
{
    [Binding]
    public class LogoutFunctionalityForSauceDemoApplicationStepDefinitions
    {   
        private readonly LogOutPage _logOutPage;
       
        public LogoutFunctionalityForSauceDemoApplicationStepDefinitions(LogOutPage logOutPage)
        {
            _logOutPage = logOutPage;
          
        }


        [When("user clicks on menu button")]
        public void WhenUserClicksOnMenuButton()
        {   
           
            _logOutPage.ClickMenuButton();
        }

        [When("user clicks on logout button")]
        public void WhenUserClicksOnLogoutButton()
        {
            _logOutPage.ClickLogoutButton();    
        }

        [Then("user should navigate to login page with {string}")]
        public void ThenUserShouldNavigateToLoginPageWith(string success)
        {
            _logOutPage.IsLoginPageDisplayed()
                .Should()
                .BeTrue("Expected to navigate back to login page after logout.");

        }
    }
}
