using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.SentCodeToVerificationEmail;

public record SentCodeToVerificationEmailQuery(string Email) : IRequest<ErrorOr<string>>;
