using SavingAccount.Domain.infraestructure.repository;
using SavingAccount.Domain.Interfaces.infraestructure.client;
using SavingAccount.Entity.Entities.input;
using SavingAccount.Entity.Entities.output;
using SavingAccount.Infraestructure.validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingAccount.Infraestructure.infraestructure
{
    public class ClientInfraestructure : IClientInfraestructure
    {
        public readonly IClientRepository  service;
        
       

        public ClientInfraestructure(IClientRepository service )
        {
            this.service= service;
            
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EClientOut>> GetClient()
        {

            return await service.GetClient();
        }

        public async Task<EClientOut> GetClientByIdAsync( string id)
        {

            return await service.GetClientByIdAsync(id);
        }

        public async Task<EClientOut> PostAsync(EClientIn entity)
        {
            ClientValidations val = new ClientValidations();
            var result = val.Validate(entity);
            if (!result.IsValid) 
                throw new Exception(result.Errors.First().ErrorMessage);
                


            return await service.PostAsync(entity);
        }

        public async Task<EClientOut> PutAsync(EClientIn entity)
        {
            throw new NotImplementedException();
        }
    }
}
