using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnRollProjectArchitecture.Pages
{
        public class LogOutPage : BasePage
        {
            public LogOutPage(IWebDriver driver): base(driver) { }
            
            

            #region Locators

            private By MenuButton => By.Id("react-burger-menu-btn");

            private By LogoutButton =>By.Id("logout_sidebar_link");

            private By LoginButton => By.Id("login-button");

            #endregion

            #region Actions

            public void ClickMenuButton()
            {
                helper.Click(MenuButton);
            }

            public void ClickLogoutButton()
            {
                helper.Click(LogoutButton);
            }

            public bool IsLoginPageDisplayed()
            {
                return helper.IsDisplayed(LoginButton);
            }
            
            #endregion
        }
}
