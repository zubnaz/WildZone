using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Command.Register;
public record RegisterCommand(string Email, 
                              string Alias, 
                              string Password, 
                              string ConfirmPassword, 
                              Guid GroupingId, 
                              Guid AvatarId) : IRequest<ErrorOr<string>>;
