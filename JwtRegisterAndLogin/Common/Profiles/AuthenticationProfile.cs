using Application.RequestHandlers.AuthenticationRequests.Command.Register;
using Application.RequestHandlers.AuthenticationRequests.Command.VerificateEmail;
using Application.RequestHandlers.AuthenticationRequests.Query.Login;
using AutoMapper;
using Domain.Models.Requests;

namespace JwtRegisterAndLogin.Common.Profiles;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<LoginRequest, LoginQuery>();

        CreateMap<VerificateEmailRequest, VerificateEmailCommand>();

        CreateMap<RegisterRequest, RegisterCommand>();
    }
}
