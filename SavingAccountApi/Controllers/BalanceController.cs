using Microsoft.AspNetCore.Mvc;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Api.Controllers
{
    #region DEFINICION DE VERSION DE API
    [ApiVersion("1")]
    #endregion DEFINICION DE VERSION DE API

    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class BalanceController : ControllerBase 
    {
        public readonly IBalanceInfraestructure infraestructure;

        public BalanceController(IBalanceInfraestructure infraestructure)
        {
            this.infraestructure = infraestructure;
        }

        #region RESOURCE_BALANCE GET
        [HttpGet]
        [Route(EConstants.RESOURCE_BALANCE)]
        public async Task<IActionResult> GetAllAsync()
        {
     
            try
            {
                return Ok(await infraestructure.GetBalance());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }                        

        [HttpGet]
        [Route(EConstants.RESOURCE_BALANCE_ID)]
        public async Task<IActionResult> GetBalanceByIdAsync(string id )
        {

            try
            {
                return Ok(await infraestructure.GetBalanceByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion RESOURCE_BALANCE GET

        #region RESOURCE_BALANCE POST
        [HttpPost]
        [Route(EConstants.RESOURCE_CREATE_BALANCE)]
        public async Task<IActionResult> PostAsync([FromQuery] EBalanceIn eBalanceSearch)
        {
            
            try
            {
                return Ok(await  infraestructure.PostAsync(eBalanceSearch));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        #endregion RESOURCE_BALANCE POST
    }
}
