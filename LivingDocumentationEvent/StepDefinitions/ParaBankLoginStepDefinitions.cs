using LivingDocumentationEvent.Models;
using LivingDocumentationEvent.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LivingDocumentationEvent.StepDefinitions
{
    public class ParaBankLoginStepDefinitions
    {
        private User user;
        private WebDriver driver;

        [BeforeScenario]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given("a user with username {word} and password {word}")]
        public void GivenAUserWithUsernameJohnAndPasswordDemo(string username, string password)
        {
            user = new User
            {
                Username = username,
                Password = password
            };
        }

        [When("they perform a login on the ParaBank frontend")]
        public void WhenTheyPerformALoginOnTheParaBankFrontend()
        {
            new LoginPage(driver)
                .Open()
                .LoginAs(user.Username, user.Password);
        }

        [Then("the login should be successful")]
        public void ThenTheLoginShouldBeSuccessful()
        {
        }

        [AfterScenario]
        public void StopBrowser()
        {
            this.driver.Quit();
        }
    }
}
