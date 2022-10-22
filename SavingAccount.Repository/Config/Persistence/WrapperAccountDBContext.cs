using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Model;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace SavingAccount.Repository.Config.Persistence
{
    public class WrapperAccountDBContext
    {
        //public virtual AccountDBContext CreateContext(string stringConnection)
        //{
        //    return new AccountDBContext(stringConnection);
        //}

        //public void DisposeBdd(AccountDBContext bdd)
        //{
        //    if (bdd != null)
        //    {
        //        bdd.Dispose();
        //    }
        //}
    }
}
