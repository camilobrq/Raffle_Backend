using Domain.Entities.Base;
using Domain.Entities.Raflee;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.GetProduct
{
    public class GetProductHandler(ProductService _productService, IMapper _Imapper)
    : IRequestHandler<GetProductCommand, ServiceResponse>
    {

        public async Task<ServiceResponse> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var product = _Imapper.Map<Product>(request);
            var result = await _productService.GetAllProductByIdUser(product);
            return new ServiceResponse<IEnumerable<Product>>(string.Empty, result, true);
        }
    }
}
