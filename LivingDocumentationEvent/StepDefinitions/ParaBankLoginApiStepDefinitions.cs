using LivingDocumentationEvent.Models;
using NUnit.Framework;
using static RestAssured.Dsl;

namespace LivingDocumentationEvent.StepDefinitions
{
    public class ParaBankLoginApiStepDefinitions
    {
        private User user;
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
            customerId = (long)Given()
                .Accept("application/json")
                .When()
                .Get($"http://localhost:8080/parabank/services/bank/login/{user.Username}/{user.Password}")
                .Then()
                .Extract()
                .Body("$.id");                
        }

        [Then("the login should be successful")]
        public void ThenTheLoginShouldBeSuccessful()
        {
            Assert.That(customerId, Is.EqualTo(user.Id));
        }
    }
}
