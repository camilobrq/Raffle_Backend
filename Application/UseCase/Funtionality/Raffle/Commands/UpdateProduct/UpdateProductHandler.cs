using Domain.Entities.Base;
using Domain.Entities.Raflee;
using Domain.Services;

namespace Application.UseCase.Funtionality.Raffle.Commands.UpdateProduct
{
    public class UpdateProductHandler(ProductService _productService, IMapper _Imapper)
    : IRequestHandler<UpdateProductCommand, ServiceResponse>
    {

        public async Task<ServiceResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _Imapper.Map<Product>(request);
            product.LastModifiedOn = DateTime.Now;
            await _productService.UpdateProduct(product);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
