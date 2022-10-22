using SavingAccount.Entity.Entities.input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavingAccount.Entity.Model
{
    public class ClientModel 
    {
        [Key]
        public string ID_CLIENT { get; set; } 
        public string NAME { get; set; }
        public DateTime CEATION_DATE { get; set; } = DateTime.Now;
        public virtual  List<AccountModel> ACCOUNT_LIST { get; set; }
    }
}
