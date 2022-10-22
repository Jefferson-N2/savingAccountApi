using System;

namespace SavingAccount.Entity.Entities.input
{
    public class ETransactionIn : EClientIn
    {
        public decimal Amount { get; set; }
        public int Percent { get; set; } 
        public int Month { get; set; }

    }
}
