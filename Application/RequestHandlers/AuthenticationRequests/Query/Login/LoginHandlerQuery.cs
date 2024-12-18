using Application.Interfaces;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.Login;

public class LoginHandlerQuery(
    IAuthenticationRepository authenticationRepository,
    IJWTService jWTService) : IRequestHandler<LoginQuery, string>
{
    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var stalker = await authenticationRepository.IsUserExist(request.Email);

        if (stalker == null)
            return "User isn't exist";        

        var result = await authenticationRepository.IsPasswordCorrect(stalker, request.Password);

        if(result == false)
            return "Wrong password";

        var token = await jWTService.GenerateJWTToken(stalker);

        return token.Token.ToString();
    }
}
