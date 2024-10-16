using Application.UseCase.Funtionality.Raffle.Commands.CreateProduct;
using Application.UseCase.Funtionality.Raffle.Commands.CreateRaffle;
using Application.UseCase.Funtionality.Raffle.Commands.CreateService;
using Application.UseCase.Funtionality.Raffle.Commands.DeleteProduct;
using Application.UseCase.Funtionality.Raffle.Commands.GetProduct;
using Application.UseCase.Funtionality.Raffle.Commands.UpdateProduct;
using Application.UseCase.Funtionality.Raffle.Commands.UpdateService;
using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Raffle;
using Domain.Entities.Raflee;

namespace Application.UseCase.Funtionality.Raffle
{
    public class RaffleProfile : Profile
    {
        public RaffleProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductCommand, Product>().ReverseMap();
            CreateMap<DeleteProductCommand, Product>().ReverseMap();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<UpdateServiceCommand, Service>().ReverseMap();
            CreateMap<CreateRaffleCommand, Domain.Entities.Raffle.Raffle>().ReverseMap();
        }
    }
}
