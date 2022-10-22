
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SavingAccount.Entity.Model
{
    public class AccountModel
    {  
        
        public int ID_ACCOUNT { get; set; }
        [Key]
        public string ACCOUNT_NUMBER { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ID_CLIENT { get; set; } 

        public virtual ClientModel CLIENT { get; set; }
        public virtual List<BalanceModel> BALANCE_LIST { get; set; }

    }
}
