using System;
using LivingDocumentationEvent.Models;
using Reqnroll;

namespace LivingDocumentationEvent.StepDefinitions
{
    [Binding]
    public class LoanApplicationExample01BeforeStepDefinitions
    {
        private User user = new User();
        private Account account = new Account();
        private LoanApplication loanApplication = new LoanApplication();

        [Given("{word} is a registered bank user")]
        public void GivenARegisteredBankUser(string username)
        {
            user.Name = username;
        }

        [Given("^their line of credit is (valid|invalid)$")]
        public void GivenTheirLineOfCreditIsValidOrInvalid(string validity)
        {
            user.ValidLineOfCredit = validity.Equals("valid", StringComparison.OrdinalIgnoreCase);
        }

        [Given("they have a {word} account with ID {int}")]
        public void GivenTheyHaveACheckingAccountWithNumber(string accountType, int accountId)
        {
            account.Type = accountType;
            account.Id = accountId;
        }

        [Given("their account {int} has a balance of {int}")]
        public void GivenTheirAccountHasABalanceOf(int accountNumber, int balance)
        {
            account.Balance = balance;
        }

        [When("they seek a {int} dollar loan")]
        public void WhenTheyApplyForADollarLoan(int loanAmount)
        {
            loanApplication.Amount = loanAmount;
        }

        [When("the monthly down payment is {int}")]
        public void WhenTheMonthlyDownPaymentIs(int downPayment)
        {
            loanApplication.DownPayment = downPayment;
        }

        [When("the monthly down payment is deducted from account {int}")]
        public void WhenTheMonthlyDownPaymentIsDeductedFromAccount(int fromAccountId)
        {
            loanApplication.FromAccountId = fromAccountId;
        }

        [When("the loan application is submitted")]
        public void WhenTheLoanApplicationIsSubmitted()
        {
            // ... this is where the actual loan is submitted, using the
            // user, account and loanapplication objects as input.
        }

        [Then("^the loan application is (approved|denied)$")]
        public void ThenTheLoanApplicationIsApprovedOrDenied(string loanApplicationResult)
        {
            // Check the application result
        }
    }
}
