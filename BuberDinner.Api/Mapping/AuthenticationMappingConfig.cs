using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Mapping
{
 public class AuthenticationMappingConfig : IRegister
 {
        public void Register(TypeAdapterConfig config)
        {
            // config.NewConfig<RegisterRequest, RegisterCommand>()
            //   .Map(dest => dest.FirstName, src => src.FirstName)
            //   .Map(dest => dest.LastName, src => src.LastName)
            //   .Map(dest => dest.Email, src => src.Email)
            //   .Map(dest => dest.Password, src => src.Password);

            // config.NewConfig<LoginRequest, LoginQuery>()
            //   .Map(dest => dest.Email, src => src.Email)
            //   .Map(dest => dest.Password, src => src.Password);
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
             // .Map(dest => dest.Id, src => src.User.Id)
             
             .Map(dest => dest, src => src.User);
      
  }
 }
}