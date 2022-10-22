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
    public class AccountController : ControllerBase 
    {
        public readonly IAccountInfraestructure infraestructure;

        public AccountController(IAccountInfraestructure infraestructure)
        {
            this.infraestructure = infraestructure;
        }

        #region EConstants.RESOURCE_ACCOUNT GET

        [HttpGet]
        [Route(EConstants.RESOURCE_ACCOUNT)]
        public async Task<IActionResult>GetAllAsync()
        {
            try
            {
                return Ok(await infraestructure.GetAccount());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        [HttpGet]
        [Route(EConstants.RESOURCE_ACCOUNT_ID)]
        public async Task<IActionResult> GetAccountByIdAsync([FromQuery] string id)
        {
            try
            {
                return Ok(await infraestructure.GetAccountByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route(EConstants.RESOURCE_CREATE_ACCOUNT)]
        public async Task<IActionResult> PostAsync(EAccountIn eAccountSearch)
        {
            try
            {
                return Ok(await infraestructure.PostAsync(eAccountSearch));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        #endregion EConstants.RESOURCE_ACCOUNT GET
    }
}
