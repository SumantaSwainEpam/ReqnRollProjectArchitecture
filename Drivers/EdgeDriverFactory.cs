using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using ReqnRollProjectArchitecture.Drivers;

namespace ReqnRollProjectArchitecture.Drivers
{
    #region EdgeDriverFactory
    public class EdgeDriverFactory : IDriverFactory
    {
        /// <summary>
        ///  Creates and configures a new instance of the Edge WebDriver.
        ///  This method initializes the Edge browser with specific options,
        /// </summary>
        /// <returns></returns>
        public IWebDriver CreateDriver()
        {
            var options = GetEdgeOptions();
            var driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;

        }
        /// <summary>
        ///  Gets the Edge options for the WebDriver. This method configures the Edge browser to run in headless mode,disables popup blocking, and enables guest mode. These settings are useful for automated testing scenarios where a graphical user interface is not required,
        ///  and it helps to ensure that tests run smoothly without interruptions from popups or other browser features.
        /// </summary>
        /// <returns></returns>
        private EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions();
            if (Credentials.CredentialsManager.IsHeadless())
            {
                options.AddArgument("--headless=new");
            }
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--guest");
            options.AddArgument("--disable-popup-blocking");
            return options;
        }
    }
    #endregion
}
