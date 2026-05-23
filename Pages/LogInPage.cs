using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnRollProjectArchitecture.Pages 
{ 

      public class LogInPage : BasePage
      {
            public LogInPage(IWebDriver driver) : base(driver) { }
        
            
        

            #region Locators

            private By UserNameInput => By.Id("user-name");

            private By PasswordInput => By.Id("password");

            private By LoginButton => By.Id("login-button");

            private By AppLogo => By.CssSelector(".app_logo");

            private By ErrorMessage => By.CssSelector("[data-test='error']");

            #endregion

            #region Actions

            public void NavigateToApplication(string url)
            {
                driver.Navigate().GoToUrl(url);
            }

            public void EnterUserName(string username)
            {
                helper.Type(UserNameInput, username);
            }

            public void EnterPassword(string password)
            {
                helper.Type(PasswordInput, password);
            }

            public void ClickLoginButton()
            {
                helper.Click(LoginButton);
            }

            public bool IsAppLogoDisplayed()
            {
                return helper.IsDisplayed(AppLogo);
            }

            public bool IsErrorMessageDisplayed()
            {
                return helper.IsDisplayed(ErrorMessage);
            }

            public string GetAppLogoText()
            {
                return helper.GetText(AppLogo);
            }
            
            public bool IsAppLogoTextCorrect(string expectedText)
            {
                string actualText = GetAppLogoText();
                return string.Equals(actualText, expectedText, StringComparison.OrdinalIgnoreCase);
            }

           
        #endregion

      }
}




