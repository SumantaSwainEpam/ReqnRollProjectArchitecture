using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace ReqnRollProjectArchitecture.Drivers
{
    #region FirefoxDriverFactory
    public class FirefoxDriverFactory : IDriverFactory
    {
        /// <summary>
        ///  Creates and configures a new instance of the Firefox WebDriver. This method initializes the Firefox browser with specific options,
        ///  such as running in headless mode, enabling guest mode, and disabling popup blocking. After configuring the options, 
        ///  it creates a new FirefoxDriver instance, maximizes the browser window,
        ///  and returns the configured WebDriver for use in automated testing scenarios.
        /// </summary>
        /// <returns></returns>
        public IWebDriver CreateDriver()
        {
            var options = GetFirefoxOptions();
            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;

        }

        /// <summary>
        ///  Gets the Firefox options for the WebDriver. This method configures the Firefox browser to run in headless mode,
        ///  enables guest mode, and disables popup blocking. These settings are useful for automated testing scenarios where a graphical user interface is not required, 
        ///  and it helps to ensure that tests run smoothly without interruptions from popups or other browser features.
        /// </summary>
        /// <returns></returns>
        private FirefoxOptions GetFirefoxOptions()
        {
            var options = new FirefoxOptions();
            if (Credentials.CredentialsManager.IsHeadless())
            {
                options.AddArgument("--headless");
            }
            options.AddArgument("--guest");
            options.AddArgument("--disable-popup-blocking");
            return options;
        }
    }
    #endregion FirefoxDriverFactory

}
