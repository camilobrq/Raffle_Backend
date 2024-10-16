using Application.UseCase.Security.Authentication.Commands.SignUp;
using Domain.Entities.Base;
using Domain.Entities.Raflee;
using Domain.Entities.Security;
using Domain.Services;
using Domain.Utils;

namespace Application.UseCase.Funtionality.Raffle.Commands.CreateProduct
{
    public class CreateProductHandler(ProductService _productService, IMapper _Imapper)
    : IRequestHandler<CreateProductCommand, ServiceResponse>
    {

        public async Task<ServiceResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _Imapper.Map<Product>(request);
            product.Id = Guid.NewGuid();
            product.CreatedOn = DateTime.Now;
            await _productService.AddProduct(product);
            return new ServiceResponse(string.Empty, true);
        }
    }

}
