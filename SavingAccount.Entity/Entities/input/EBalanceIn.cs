
namespace SavingAccount.Entity.Entities.input
{
    public class EBalanceIn 
    {
        public string IdClient { get; set; }
        public string  AccountNumber   { get; set; }
        public decimal DebitValue  { get; set; }
        public decimal CreditValue{ get; set; }
        public decimal TotalValue { get; set; }
        public int Month { get; set; }
    }
}
