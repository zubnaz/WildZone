using Domain.Models.Entities;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfAvatarsByGroupingId;

public record GetListOfAvatarsByGroupingIdQuery(Guid GroupingId) : IRequest<ErrorOr<List<Avatar>>>;
