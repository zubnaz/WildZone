using Application.Interfaces;
using Domain.Models.Entities;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfGrouping;

public class GetListOfGroupingQueryHandler(IGroupingRepository groupingRepository) : IRequestHandler<GetListOfGroupingQuery, ErrorOr<List<Grouping>>>
{
    public async Task<ErrorOr<List<Grouping>>> Handle(GetListOfGroupingQuery request, CancellationToken cancellationToken)
    {
        return await groupingRepository.GetListOfGroupingAsync();
    }
}
