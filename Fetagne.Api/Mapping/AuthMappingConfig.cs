namespace Fetagne.Api.Mapping;

using Fetagne.Application.Services.Auth.Common;
using Fetagne.Contracts.Auth;
using Mapster;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthResult, AuthResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest=> dest, src => src.User);
    }
}