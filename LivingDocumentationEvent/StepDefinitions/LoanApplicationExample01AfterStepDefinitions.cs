using System;
using LivingDocumentationEvent.Models;
using Reqnroll;

namespace LivingDocumentationEvent.StepDefinitions
{
    [Binding]
    public class LoanApplicationExample01AfterStepDefinitions
    {
        private User user;
        private Account account;
        private LoanApplication loanApplication;

        [Given("a registered bank user")]
        public void GivenARegisteredBankUser(DataTable dataTable)
        {
            user = dataTable.CreateInstance<User>();
        }

        [Given("they have a bank account")]
        public void GivenTheyHaveABankAccount(DataTable dataTable)
        {
            account = dataTable.CreateInstance<Account>();
        }

        [When("they submit a loan application")]
        public void WhenTheySubmitALoanApplication(DataTable dataTable)
        {
            loanApplication = dataTable.CreateInstance<LoanApplication>();

            // ... this is also where the actual loan is submitted
        }
    }
}
