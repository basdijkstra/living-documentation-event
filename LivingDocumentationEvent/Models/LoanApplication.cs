namespace LivingDocumentationEvent.Models
{
    public class LoanApplication
    {
        public string Applicant {  get; set; }
        public int Amount { get; set; }
        public int DownPayment { get; set; }
        public int FromAccountId { get; set; }
        public string Status { get; set; } = "New";
    }
}
