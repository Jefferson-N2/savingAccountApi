using Microsoft.AspNetCore.Mvc;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity;
using SavingAccount.Entity.Entities.input;
using System;
using System.Threading.Tasks;

namespace SavingAccount.Api.Controllers
{
    #region DEFINICION DE VERSION DE API
    [ApiVersion("1")]
    #endregion DEFINICION DE VERSION DE API

    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class TransactionController : ControllerBase 
    {
        public readonly ITransactionInfraestructure infraestructure;

        public TransactionController(ITransactionInfraestructure infraestructure)
        {
            this.infraestructure = infraestructure;
        }

        [HttpPost]
        [Route(EConstants.RESOURCE_CREATE_ACCOUNT)]
        public async Task<IActionResult> PostAsync(ETransactionIn transaction)
        {
            try
            {
                return Ok(await infraestructure.generateAccount(transaction));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
