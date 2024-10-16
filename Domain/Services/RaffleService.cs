using Domain.Entities.Raffle;
using Domain.Ports.Repository;
using Notes.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    [DomainService]
    public class RaffleService(IRafflesRepository raffleRepository)
    {
        public async Task<string> AddRaffle(Raffle service)
        {
            try
            {
                var result =await raffleRepository.AddNumberReffle(service);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteRaffleById(Guid id)
        {
            try
            {
                await raffleRepository.DeleteRaffle(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
