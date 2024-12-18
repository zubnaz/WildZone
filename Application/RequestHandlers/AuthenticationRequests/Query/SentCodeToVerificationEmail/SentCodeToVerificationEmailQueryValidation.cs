using FluentValidation;

namespace Application.RequestHandlers.AuthenticationRequests.Query.SentCodeToVerificationEmail;

public class SentCodeToVerificationEmailQueryValidation : AbstractValidator<SentCodeToVerificationEmailQuery>
{
    public SentCodeToVerificationEmailQueryValidation()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email must not be empty")
            .EmailAddress().WithMessage("Wrong format of email address");

    }
}
