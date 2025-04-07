using LivingDocumentationEvent.Models;
using LivingDocumentationEvent.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static RestAssured.Dsl;

namespace LivingDocumentationEvent.StepDefinitions
{
    [Binding]
    public class ParaBankLoginFrontendStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private User user;
        private WebDriver driver;
        private long customerId;

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




































        [When("they perform a login on the ParaBank API")]
        public void WhenTheyPerformALoginOnTheParaBankApi()
        {
            customerId = (long)Given()
                .Accept("application/json")
                .When()
                .Get($"http://localhost:8080/parabank/services/bank/login/{user.Username}/{user.Password}")
                .Then()
                .Extract()
                .Body("$.id");
        }

        [Then("the API login should be successful")]
        public void ThenTheAPILoginShouldBeSuccessful()
        {
            Assert.That(customerId, Is.EqualTo(user.Id));
        }
    }
}
