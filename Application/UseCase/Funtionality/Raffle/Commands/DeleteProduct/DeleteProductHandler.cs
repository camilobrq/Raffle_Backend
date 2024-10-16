using Domain.Entities.Base;
using Domain.Entities.Raflee;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.DeleteProduct
{
    public class DeleteProductHandler(ProductService _productService)
    : IRequestHandler<DeleteProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductById(request.Id);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
