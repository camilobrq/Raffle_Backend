using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.DeleteProduct;

public record DeleteProductCommand(
    Guid Id
) : IRequest<ServiceResponse>;
