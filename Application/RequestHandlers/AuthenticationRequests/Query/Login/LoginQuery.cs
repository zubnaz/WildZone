using MediatR;

namespace Application.RequestHandlers.AuthenticationRequests.Query.Login;

public record LoginQuery(string Email, string Password) : IRequest<string>; 
