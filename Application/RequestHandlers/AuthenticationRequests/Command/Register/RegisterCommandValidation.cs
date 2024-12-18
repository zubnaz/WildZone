using FluentValidation;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Command.Register;

public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidation()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .EmailAddress().WithMessage("Wrong format of email address");

        RuleFor(e => e.Alias)
            .NotEmpty().WithMessage("{PropertyName} must not be empty");      

        RuleFor(e => e.Password)
            .Equal(e => e.ConfirmPassword)
            .WithMessage(e => $"{nameof(e.Password)} and {nameof(e.ConfirmPassword)} must be equal");

        RuleFor(e => e.GroupingId)
            .NotEmpty().WithMessage("{PropertyName} must not be empty");

        RuleFor(e => e.AvatarId)
            .NotEmpty().WithMessage("{PropertyName} must not be empty");
    }
}
