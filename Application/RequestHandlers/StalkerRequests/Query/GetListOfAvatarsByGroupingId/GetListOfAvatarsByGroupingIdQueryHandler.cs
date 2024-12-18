using Application.Interfaces;
using Domain.Models.Entities;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfAvatarsByGroupingId;

public class GetListOfAvatarsByGroupingIdQueryHandler(IAvatarRepository avatarsRepository) : IRequestHandler<GetListOfAvatarsByGroupingIdQuery, ErrorOr<List<Avatar>>>
{
    public async Task<ErrorOr<List<Avatar>>> Handle(GetListOfAvatarsByGroupingIdQuery request, CancellationToken cancellationToken)
    {
        return await avatarsRepository.GetListOfAvatarsByGroupingIdAsync(request.GroupingId);
    }
}
