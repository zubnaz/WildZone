using Application.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.CheckIsEmailExist;

public class CheckIsEmailExistQueryHandler(IAuthenticationRepository repository) : IRequestHandler<CheckIsEmailExistQuery, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(CheckIsEmailExistQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.IsUserExist(request.Email);

        if (result != null)
            return "A user with this email address exists";

        if(!request.Email.Contains("@"))
            return Error.Validation(description:$"{request.Email} isn't mail adress");

        return request.Email;
        
    }
}
