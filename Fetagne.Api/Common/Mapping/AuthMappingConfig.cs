namespace Fetagne.Api.Mapping;
using Mapster;
using Fetagne.Application.Services.Auth.Common;
using Fetagne.Contracts.Auth;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        Console.WriteLine("AuthMappingConfig");
        config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest=> dest, src => src.User);
    }
}