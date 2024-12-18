using Application.Helpers;
using Application.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.SentCodeToVerificationEmail;

public class SentCodeToVerificationEmailQueryHandler(IAuthenticationRepository authenticationRepository,
                                                    IMailService mailService) : IRequestHandler<SentCodeToVerificationEmailQuery, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(SentCodeToVerificationEmailQuery request, CancellationToken cancellationToken)
    {
        var isUserExist = await authenticationRepository.IsUserExist(request.Email);

        if (isUserExist != null)
            return Error.Conflict(description : $"User with {request.Email} alredy exists");


       var verificationCode = CodeGenerator.GenerateCode();
       await authenticationRepository.AddNewEmailVerificationAsync(request.Email, verificationCode);
       await mailService.SentMailAsync(request.Email, "Verification Code", verificationCode);

        return request.Email;
    }
}
