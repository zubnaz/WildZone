using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.CheckIsEmailExist;

public record CheckIsEmailExistQuery(string Email) : IRequest<ErrorOr<string>>;
