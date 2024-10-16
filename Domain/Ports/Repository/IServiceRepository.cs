using Domain.Entities.Raffle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Repository
{
    public interface IServiceRepository
    {
        Task AddService(Service serviceModel);
        Task<List<Service>> GetServiceByIdClient(Guid IdUser, bool State);
        Task UpdateService(Service serviceModel);
        Task DeleteService(Guid Id);
    }
}
