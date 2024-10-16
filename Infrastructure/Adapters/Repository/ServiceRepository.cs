using Domain.Entities.Raffle;
using Domain.Ports.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly RaffleDbContext context;

        public ServiceRepository(RaffleDbContext context)
        {
            this.context = context;
        }

        public async Task AddService(Service serviceModel)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            serviceModel.Id = Guid.NewGuid();
            serviceModel.CreatedOn = DateTime.Now;
            serviceModel.State = true;
            context.Add(serviceModel);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        public async Task<List<Service>> GetServiceByIdClient(Guid IdUser, bool State)
        {
            var services = await context.Services
            .Where(r => r.IdUser == IdUser && r.State == State)
            .ToListAsync();

            return services;
        }

        public async Task UpdateService(Service serviceModel)
        {
            var existingTask = await context.Services.FindAsync(serviceModel.Id);

            if (existingTask != null)
            {
                existingTask.Name = serviceModel.Name;
                existingTask.Description = serviceModel.Description;
                existingTask.Price = serviceModel.Price;
                existingTask.LastModifiedOn = DateTime.Now;
                existingTask.IdUser = serviceModel.IdUser;
                existingTask.State = serviceModel.State;

                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteService(Guid Id)
        {
            var existingService = await context.Services.FindAsync(Id);

            if (existingService != null)
            {
                existingService.State = false;

                await context.SaveChangesAsync();
            }
        }
    }
}
