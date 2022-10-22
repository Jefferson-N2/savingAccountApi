using System;
using System.Collections.Generic;
namespace SavingAccount.Entity.Entities.output
{
    public class EClientOut 
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<EAccountOut> accountList { get; set; }
    }
}
