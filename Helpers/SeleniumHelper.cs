using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReqnRollProjectArchitecture.Helpers
{
    public class SeleniumHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SeleniumHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(15));
        }

        #region Wait Methods

        public IWebElement WaitForVisible(By locator)
        {
            return _wait.Until(
                ExpectedConditions
                .ElementIsVisible(locator));
        }

        public IWebElement WaitForClickable(By locator)
        {
            return _wait.Until(
                ExpectedConditions
                .ElementToBeClickable(locator));
        }

        #endregion

        #region Common Actions

        public void Click(By locator)
        {
            WaitForClickable(locator).Click();
        }

        public void Type(By locator, string text)
        {
            IWebElement element =
                WaitForVisible(locator);

            element.Clear();
            element.SendKeys(text);
        }

        public void Clear(By locator)
        {
            WaitForVisible(locator).Clear();
        }

        public string GetText(By locator)
        {
            return WaitForVisible(locator).Text;
        }

        public bool IsDisplayed(By locator)
        {
            try
            {
                return WaitForVisible(locator)
                    .Displayed;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Advanced Actions

        public void ScrollToElement(By locator)
        {
            IWebElement element =
                WaitForVisible(locator);

            IJavaScriptExecutor js =
                (IJavaScriptExecutor)_driver;

            js.ExecuteScript(
                "arguments[0].scrollIntoView(true);",
                element);
        }

        public void JSClick(By locator)
        {
            IWebElement element =
                WaitForVisible(locator);

            IJavaScriptExecutor js =
                (IJavaScriptExecutor)_driver;

            js.ExecuteScript("arguments[0].click();",element);
        }

        public void Hover(By locator)
        {
            IWebElement element = WaitForVisible(locator);

            Actions actions = new Actions(_driver);

            actions.MoveToElement(element).Perform();
        }

        public void SelectDropdownByText(By locator,string visibleText)
        {

            IWebElement element = WaitForVisible(locator);
            SelectElement dropdown= new SelectElement(element);
            dropdown.SelectByText(visibleText);

        }

        public string TakeScreenshot(string name)
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            var screenshotDir = Path.Combine(projectDir ?? AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Screenshots");

            if (!Directory.Exists(screenshotDir))
            {
                Directory.CreateDirectory(screenshotDir);
            }

            string cleanName = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
            string screenshotPath = Path.Combine(screenshotDir, $"{cleanName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(screenshotPath);

            return screenshotPath;
        }

        #endregion
    }
}