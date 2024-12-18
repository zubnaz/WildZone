using FluentValidation;

namespace Application.RequestHandlers.AuthenticationRequests.Command.VerificateEmail;

public class VerificateEmailCommandValidation : AbstractValidator<VerificateEmailCommand>
{
    public VerificateEmailCommandValidation()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email must not be empty")
            .EmailAddress().WithMessage("Wrong format of email address");

        RuleFor(c => c.Code)
            .Length(7).WithMessage("Length of code must be 7");
    }
}
