using Domain.Entities.Base;
using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.UseCase.Funtionality.Raffle.Commands.UpdateProduct;
public record UpdateProductCommand(
   Guid Id, string Name, string Description, decimal Price, Guid IdUser, int State
) : IRequest<ServiceResponse>;