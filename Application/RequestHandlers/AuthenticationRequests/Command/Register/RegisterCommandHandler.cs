using Application.Interfaces;
using Data.Enums;
using Domain.Models.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.RequestHandlers.AuthenticationRequests.Command.Register;

public class RegisterCommandHandler(IAuthenticationRepository authenticationRepository, 
                                    IStalkerRepository stalkerRepository,
                                    IJWTService jWTService) : IRequestHandler<RegisterCommand, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isUserExist = await authenticationRepository.IsUserExist(request.Email);

        if (isUserExist != null)
            return Error.Conflict(description : "A user with this email address exists");

        var initialRang = await stalkerRepository.GetInitialRangAsync();

        var newStalker = new Stalker()
        {
            Alias = request.Alias,
            Email = request.Email,
            UserName = request.Email,
            RangId = initialRang,
            GroupingId = request.GroupingId,
            AvatarId = request.AvatarId,
        };
        var result = await authenticationRepository.CreateNewStalkerAsync(newStalker,request.Password, Enums.Roles.Stalker.ToString());

        if (result.IsError)
            return result.FirstError;

        var jwtToken = await jWTService.GenerateJWTToken(result.Value);

        return jwtToken.Token;
    }
}
