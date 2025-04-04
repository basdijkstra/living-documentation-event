using System;
using LivingDocumentationEvent.Models;
using Reqnroll;

namespace LivingDocumentationEvent.StepDefinitions
{
    [Binding]
    public class LoanApplicationProcessingStepDefinitions
    {
        private IEnumerable<LoanApplication>? loanApplications;

        [Given(@"the loan application workload contains the following applications:")]
        public void GivenTheLoanApplicationWorkloadContainsTheFollowingApplications(DataTable dataTable)
        {
            loanApplications = dataTable.CreateSet<LoanApplication>();
        }

        [When(@"the loan applications for (.+) are approved")]
        public void WhenTheLoanApplicationsForSusanAreApproved(string applicant)
        {
            foreach (LoanApplication loanApplication in loanApplications!)
            {
                if (loanApplication.Applicant.Equals(applicant))
                {
                    loanApplication.Status = "Approved";
                }
            }
        }

        [Then(@"the loan application workload contains the following applications:")]
        public void ThenTheLoanApplicationWorkloadContainsTheFollowingApplications(DataTable dataTable)
        {
            dataTable.CompareToSet(loanApplications);
        }
    }
}
