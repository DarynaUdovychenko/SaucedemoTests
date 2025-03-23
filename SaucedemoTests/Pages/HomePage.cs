using log4net;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public class HomePage : BasePage
    {
        private readonly By titleName = By.CssSelector(".app_logo");
        private readonly ILog log;

        public HomePage(IWebDriver driver) : base(driver)
        {
            log = LogManager.GetLogger(typeof(HomePage));
            log.Info("HomePage constructor initialized.");
        }

        public string GetTitleInDashboard()
        {
            log.Info("Retrieving dashboard title...");
            string title = GetText(titleName);

            log.Info($"Dashboard title retrieved: {title}");
            return title;
        }
    }
}
