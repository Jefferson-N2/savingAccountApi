using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavingAccount.Entity.Model
{
    public class BalanceModel
    {
        [Key]
        public int ID_Balance { get; set; }
        public string ID_CLIENT { get; set; }
        public string  ACCOUNT_NUMBER   { get; set; } 
        public int Month { get; set; }
        public decimal DEBIT_VALUE  { get; set; } 
        public decimal CREDIT_VALUE { get; set; } 
        public decimal TOTAL_VALUE { get; set; }

        public virtual AccountModel ACCOUNT { get; set; }
    }
}
