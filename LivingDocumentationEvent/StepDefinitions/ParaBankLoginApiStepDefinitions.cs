using LivingDocumentationEvent.Models;
using NUnit.Framework;
using static RestAssured.Dsl;

namespace LivingDocumentationEvent.StepDefinitions
{
    [Binding]
    public class ParaBankLoginApiStepDefinitions
    {
        private User user;
        private long customerId;

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

        [Then("the login should be successful")]
        public void ThenTheLoginShouldBeSuccessful()
        {
            Assert.That(customerId, Is.EqualTo(user.Id));
        }
    }
}
