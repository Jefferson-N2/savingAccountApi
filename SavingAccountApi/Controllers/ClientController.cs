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
    public class ClientController : ControllerBase 
    {
        public readonly IClientInfraestructure infraestructure;

        public ClientController(IClientInfraestructure infraestructure)
        {
            this.infraestructure = infraestructure;
        }

        #region RESOURCE_SAVING_ACCOUNT GET

        [HttpGet]
        [Route(EConstants.RESOURCE_CLIENT)]
        public async Task<IActionResult> GetAllAsync()
        {

            try
            {
                return Ok(await infraestructure.GetClient());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }       

        [HttpGet]
        [Route(EConstants.RESOURCE_CLIENT_ID)]
        public async Task<IActionResult> GetClientByIdAsync([FromQuery] string id)
        {
            try
            {
                return Ok(await infraestructure.GetClientByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            
            }


        }
        #endregion RESOURCE_CLIENT GET

        #region RESOURCE_CREATE_CLIENT POST

        [HttpPost]
        [Route(EConstants.RESOURCE_CREATE_CLIENT)]
        public async Task<IActionResult> PostAsync( EClientIn eClientSearch)
        {
            try
            {
                return Ok(await infraestructure.PostAsync(eClientSearch));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }

        }

    }
    #endregion  RESOURCE_CREATE_CLIENT POST
}
