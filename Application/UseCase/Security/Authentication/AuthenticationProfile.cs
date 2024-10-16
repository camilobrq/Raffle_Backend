
using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Security;

namespace Application.UseCase.Security.Authentication;

public class AuthenticationProfile: Profile
{
    public AuthenticationProfile()
    {
        CreateMap<AuthenticationDto, User>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => new Role { Code = src.Role }))
                .ReverseMap()
                .ForPath(dest => dest.Role, opts => opts.MapFrom(src => src.Role.Code));
    }
}
