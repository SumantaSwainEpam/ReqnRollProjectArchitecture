using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnRollProjectArchitecture.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnRollProjectArchitecture.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly SeleniumHelper helper;
        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            helper = new SeleniumHelper(driver);
        }
    }
}
