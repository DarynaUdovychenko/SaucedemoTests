using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SaucedemoTests.Tests;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SaucedemoTests
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateDriver(BrowserConfig config);
    }

    public class WebDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver(BrowserConfig config)
        {
            IWebDriver driver;
            switch (config.Browser.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    if (config.Headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxOptions = new FirefoxOptions();
                    if (config.Headless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeOptions = new EdgeOptions();
                    if (config.Headless)
                    {
                        edgeOptions.AddArgument("headless");
                    }
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {config.Browser}");
            }

            driver.Manage().Window.Size = new System.Drawing.Size(config.WindowSize.Width, config.WindowSize.Height);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(config.ImplicitWaitSeconds);

            return driver;
        }
    }
}
