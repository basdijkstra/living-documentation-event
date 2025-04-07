using LivingDocumentationEvent.Models;
using LivingDocumentationEvent.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LivingDocumentationEvent.StepDefinitions
{
    public class ParaBankLoginFrontendStepDefinitions
    {
        private User user;
        private WebDriver driver;

        [Given("a user with username {word} and password {word}")]
        public void GivenAUserWithUsernameJohnAndPasswordDemo(string username, string password)
        {
            user = new User
            {
                Id = 12212,
                Username = username,
                Password = password
            };
        }

        [When("they perform a login on the ParaBank frontend")]
        public void WhenTheyPerformALoginOnTheParaBankFrontend()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            new LoginPage(driver)
                .Open()
                .LoginAs(user.Username, user.Password);
        }

        [Then("the frontend login should be successful")]
        public void ThenTheFrontendLoginShouldBeSuccessful()
        {
            Assert.That(new AccountsOverviewPage(driver).IsVisible(), Is.True);

            driver.Quit();
        }
    }
}
