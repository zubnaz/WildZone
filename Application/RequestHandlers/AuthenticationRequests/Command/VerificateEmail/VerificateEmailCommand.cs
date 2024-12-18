using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Command.VerificateEmail;
public record VerificateEmailCommand(string Email, string Code) : IRequest<ErrorOr<Success>>;
