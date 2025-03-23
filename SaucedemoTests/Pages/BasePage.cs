using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using log4net;

namespace SaucedemoTests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected string baseURL = "https://www.saucedemo.com/";
        private readonly ILog log;

        public BasePage(IWebDriver webDriver)
        {
            log = LogManager.GetLogger(typeof(BasePage));
            log.Info("BasePage constructor initialized.");

            Driver = webDriver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement FindElement(By locator)
        {
            log.Info($"Finding element with locator: {locator}");
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            log.Info($"Element found: {locator}");
            return element;
        }

        protected void EnterText(By locator, string text)
        {
            log.Info($"Entering text: {text} into element with locator: {locator}");
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
            log.Info($"Text entered: {text}");

        }

        protected void Click(By locator)
        {
            log.Info($"Clicking element with locator: {locator}");
            FindElement(locator).Click();
            log.Info($"Element was clicked");

        }

        protected string GetText(By locator)
        {
            log.Info($"Getting text from element with locator: {locator}");
            var text = FindElement(locator).Text;
            log.Info($"Text retrieved: {text}");
            return text;
        }

        protected void ClearFieldWithSendKeys(By locator)
        {
            log.Info($"Clearing field with locator: {locator}");
            FindElement(locator).SendKeys(Keys.Control + "a");
            FindElement(locator).SendKeys(Keys.Delete);
            log.Info($"Field cleared");
        }
    }
}
