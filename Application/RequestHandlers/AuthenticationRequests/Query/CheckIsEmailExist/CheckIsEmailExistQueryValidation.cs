using FluentValidation;

namespace Application.RequestHandlers.AuthenticationRequests.Query.CheckIsEmailExist;

public class CheckIsEmailExistQueryValidation : AbstractValidator<CheckIsEmailExistQuery>
{
    public CheckIsEmailExistQueryValidation()
    {
        RuleFor(r => r.Email).MinimumLength(3).EmailAddress().WithMessage("It's not email adress");
    }
}
