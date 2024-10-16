using Azure.Core;
using Domain.Entities.Raffle;
using Domain.Ports.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Repository
{
    internal class RafflesRepository: IRafflesRepository
    {
        private readonly RaffleDbContext context;

        public RafflesRepository(RaffleDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddNumberReffle(Raffle raffleModel)
        {
            const int MinNumber = 00001;
            const int MaxNumber = 99999;
            string assignedNumber = string.Empty;

            var UserHavCode = await context.Raffles
                .FirstOrDefaultAsync(n => n.UserId == raffleModel.UserId && n.ClientId == raffleModel.ClientId && n.State==true);
            if (UserHavCode == null)
            {
                for (int number = MinNumber; number <= MaxNumber; number++)
                {
                    string formattedNumber = number.ToString("D5");
                    if (!await context.Raffles.AnyAsync(n => n.CodeGenerate == formattedNumber) &&
                        !HasEqualConsecutiveDigits(number))
                    {
                        assignedNumber = number.ToString("D5");
                        break;
                    }
                }
                if (assignedNumber != string.Empty)
                {
                    var raffles = new Raffle
                    {
                        Id = Guid.NewGuid(),
                        CodeGenerate = assignedNumber,
                        UserId = raffleModel.UserId,
                        ClientId = raffleModel.ClientId,
                        CreatedOn = DateTime.Now,
                    };
                    context.Raffles.Add(raffles);
                    await context.SaveChangesAsync();
                }
                
            }
            return assignedNumber;

        }
        private bool HasEqualConsecutiveDigits(int numero)
        {
            var numStr = numero.ToString("D5");
            for (int i = 0; i < numStr.Length - 2; i++)
            {
                if (numStr[i] == numStr[i + 1] && numStr[i] == numStr[i + 2])
                {
                    return true;
                }
            }
            return false;
        }
        public async Task DeleteRaffle(Guid Id)
        {
            
            try
            {
                var existingRaffle = await context.Raffles.FindAsync(Id);

                if (existingRaffle != null)
                {
                    existingRaffle.State = false;

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
