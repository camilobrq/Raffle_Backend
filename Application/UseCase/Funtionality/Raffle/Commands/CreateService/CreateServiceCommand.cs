using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.CreateService;

public record CreateServiceCommand(
    string Name, string Description, decimal Price, Guid IdUser
) : IRequest<ServiceResponse>;
