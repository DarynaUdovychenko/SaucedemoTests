using OpenQA.Selenium;
using System.Text.Json;
using log4net;
using log4net.Config;


namespace SaucedemoTests.Tests
{
    public class BaseTests : IDisposable
    {
        protected IWebDriver Driver;
        private readonly BrowserConfig config;
        private bool disposed = false;
        private readonly ILog log;

        public BaseTests()
        {
            var log4netConfig = new FileInfo("logs/log4net.config");
            XmlConfigurator.Configure(log4netConfig);
            log = LogManager.GetLogger(typeof(BaseTests));
            log.Info("BaseTests constructor initialized.");

            string browserEnv = Environment.GetEnvironmentVariable("BROWSER")?.ToLower() ?? "chrome";
            log.Info($"Selected browser: {browserEnv}");

            string configFileName = $"browserConfig-{browserEnv}.json";
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), "Config", configFileName);
            log.Info($"Loading browser configuration from {configPath}");

            var configJson = File.ReadAllText(configPath);
            config = JsonSerializer.Deserialize<BrowserConfig>(configJson);
            log.Info($"Browser configuration loaded: Browser={config.Browser}, Headless={config.Headless}, WindowSize={config.WindowSize.Width}x{config.WindowSize.Height}, ImplicitWaitSeconds={config.ImplicitWaitSeconds}");

            var factory = new WebDriverFactory();
            Driver = factory.CreateDriver(config);
            log.Info("Browser setup completed.");
        }

        public void Dispose()
        {
            if (!disposed)
            {
                log.Info("Disposing WebDriver...");
                Driver?.Quit();
                Driver?.Dispose();
                log.Info("WebDriver disposed.");
                disposed = true;
            }
        }
    }
}
