
namespace SavingAccount.Entity.Entities.output
{
    public class EBalanceOut
    {
        public string IdClient { get; set; }
        public string  AccountNumber { get; set; }
        public decimal Month { get; set; }
        public decimal DebitValue { get; set; }
        public decimal CreditValue { get; set; }
        public decimal TotalValue { get; set; }
    }
}
