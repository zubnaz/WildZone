using Application.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Command.VerificateEmail;

public class VerificateEmailcommandHandler(IAuthenticationRepository repository) : IRequestHandler<VerificateEmailCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(VerificateEmailCommand request, CancellationToken cancellationToken)
    {
        var isEmailExist = await repository.IsEmailToVerificationExistAsync(request.Email);

        if (!isEmailExist)
            return Error.Conflict(description : "The code has expired. Want to get a new one?");

        var isCodeValid = await repository.IsEmailVerificationCodeValidAsync(request.Email, request.Code);

        if (!isCodeValid)
            return Error.Conflict(description : "The code is invalid");

        await repository.ConfirmVerificationAsync(request.Email);

        return Result.Success;
    }
}
