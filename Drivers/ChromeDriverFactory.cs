using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReqnRollProjectArchitecture.Drivers
{
    #region ChromeDriverFactory
    internal class ChromeDriverFactory: IDriverFactory
    {
        /// <summary>
        ///  Creates and configures a new instance of the Chrome WebDriver. This method initializes the Chrome browser with specific options,
        ///  such as running in headless mode, enabling guest mode, and disabling popup blocking. After configuring the options, 
        ///  it creates a new ChromeDriver instance, maximizes the browser window,
        ///  and returns the configured WebDriver for use in automated testing scenarios.
        /// </summary>
        /// <returns></returns>
        public IWebDriver CreateDriver()
        {
            var options = GetChromeOptions();
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        /// <summary>
        ///  Gets the Chrome options for the WebDriver. This method configures the Chrome browser to run in headless mode,
        ///  enables guest mode, and disables popup blocking. 
        ///  These settings are useful for automated testing scenarios where a graphical user interface is not required,
        ///  and it helps to ensure that tests run smoothly without interruptions from popups or other browser features.
        /// </summary>
        /// <returns></returns>
        private ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless=new");
            options.AddArgument("--guest");
            options.AddArgument("--disable-popup-blocking");
            return options;
        }
    }
    #endregion ChromeDriverFactory
}
