using OpenQA.Selenium;
using log4net;

namespace SaucedemoTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.CssSelector("#user-name");
        private readonly By passwordField = By.CssSelector("#password");
        private readonly By loginButton = By.CssSelector("#login-button");
        private readonly By errorMessage = By.CssSelector("h3[data-test='error']");
        private readonly ILog log;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            log = LogManager.GetLogger(typeof(LoginPage));
            log.Info("LoginPage constructor initialized.");

            log.Info("Opening URL: " + baseURL);
            Driver.Navigate().GoToUrl(baseURL);
            log.Info("URL opened.");
        }

        public void EnterUsername(string username)
        {
            log.Info($"Entering username: {username}");
            EnterText(usernameField, username);
        }

        public void EnterPassword(string password)
        {
            log.Info($"Entering password: {password}");
            EnterText(passwordField, password);
        }
        public void ClearFieldUsername()
        {
            log.Info("Clearing username field");
            ClearFieldWithSendKeys(usernameField);
        }

        public void ClearFieldPassword()
        {
            log.Info("Clearing password field");
            ClearFieldWithSendKeys(passwordField);
        }

        public void ClickLoginButton()
        {
            log.Info("Clicking login button");
            Click(loginButton);
        }

        public string GetErrorMessage()
        {
            log.Info("Retrieving error message...");
            string message = GetText(errorMessage);
            log.Info($"Error message retrieved: {message}");
            return message;
        }
    }
}
