using FluentAssertions;
using SaucedemoTests.Pages;
using log4net;

namespace SaucedemoTests.Tests
{
    [Collection("LoginTest")]
    public class LoginTest : BaseTests
    {
        private readonly ILog log;
        public LoginTest() : base()
        {
            log = LogManager.GetLogger(typeof(LoginTest));
            log.Info("LoginTest constructor initialized.");
        }

        [Fact]
        public void TestLoginWithEmptyCredentials()
        {
            log.Info("Starting TestLoginWithEmptyCredentials..");

            // Arrange
            var loginPage = new LoginPage(Driver);
            log.Info("LoginPage created");

            loginPage.EnterUsername("standard_user");
            log.Info("Usernaame was created: standard_user");

            loginPage.EnterPassword("qwertyui");
            log.Info("Password was created: qwertyui");

            loginPage.ClearFieldUsername();
            log.Info("Username field was cleared");

            loginPage.ClearFieldPassword();
            log.Info("password field was cleared");

            // Act
            loginPage.ClickLoginButton();
            log.Info("Login button was clicked.");

            // Assert
            string errorMessage = loginPage.GetErrorMessage();
            log.Info($"Error message received: {errorMessage}");
            errorMessage.Should().Be("Epic sadface: Username is required");
            log.Info("TestLoginWithEmptyCredentials completed.");
        }

        [Fact]
        public void TestLoginWithoutPassword()
        {
            //Arrange
            var loginPage = new LoginPage(Driver);
            log.Info("LoginPage created");

            loginPage.EnterUsername("standard_user");
            log.Info("Username was created: standard_user");

            loginPage.EnterPassword("qwertyui");
            log.Info("Password was created: qwertyui");

            loginPage.ClearFieldPassword();
            log.Info("Password field was cleared");

            //Act
            loginPage.ClickLoginButton();
            log.Info("Login button was clicked.");

            //Assert
            string errorMessage = loginPage.GetErrorMessage();
            log.Info($"Error message received: {errorMessage}");
            errorMessage.Should().Be("Epic sadface: Password is required");
            log.Info("TestLoginWithoutPassword completed.");

        }

        [Theory]
        [InlineData("visual_user", "secret_sauce")]
        public void TestLoginWithValidCredentials(string username, string password)
        {
            //Arrange
            var loginPage = new LoginPage(Driver);
            log.Info("LoginPage created.");

            loginPage.EnterUsername(username);
            log.Info($"Username entered: {username}");

            loginPage.EnterPassword(password);
            log.Info($"Password entered: {password}");


            //Act
            loginPage.ClickLoginButton();
            log.Info("Login button clicked.");

            //Assert
            var homePage = new HomePage(Driver);
            log.Info("HomePage created.");
            string title = homePage.GetTitleInDashboard();
            log.Info($"Dashboard title received: {title}");
            title.Should().Be("Swag Labs");
            log.Info("TestLoginWithValidCredentials completed.");
        }
    }
}
