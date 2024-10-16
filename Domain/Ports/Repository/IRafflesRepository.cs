using Domain.Entities.Raffle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repository
{
    public interface IRafflesRepository
    {
        Task<string> AddNumberReffle(Raffle raffleModel);
        Task DeleteRaffle(Guid Id);
    }
}
