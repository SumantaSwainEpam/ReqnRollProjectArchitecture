using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReqnRollProjectArchitecture.Drivers
{
    #region WebDriverFactory
    internal static class WebDriverFactory
    {
        public static IWebDriver Create(string browserType)
        {
            IDriverFactory driverFactory= browserType.ToLower() switch
            {
                "chrome" => new ChromeDriverFactory(),
                "firefox" => new FirefoxDriverFactory(),
                "edge" => new EdgeDriverFactory(),
                _ => throw new ArgumentException($"Unsupported browser type: {browserType}")
            };
            return driverFactory.CreateDriver();


        }
    }
    #endregion WebDriverFactory
}
