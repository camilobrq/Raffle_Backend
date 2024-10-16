using Domain.Entities.Raffle;
using Domain.Entities.Raflee;
using Domain.Ports;
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
    public class ServiceService(IServiceRepository serviceRepository)
    {
        public async Task AddService(Service service)
        {
            try
            {
               await serviceRepository.AddService(service);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Service>> GetAllServiceByIdUser(Guid Id, bool State)
        {
            try
            {
                var result = await serviceRepository.GetServiceByIdClient(Id, State);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateService(Service Service)
        {
            try
            {
                await serviceRepository.UpdateService(Service);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteServiceById(Guid id)
        {
            try
            {
                await serviceRepository.DeleteService(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
