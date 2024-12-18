using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfLeadersOfGroupings;
public class GetListOfLeadersOfGroupingQueryHandler(IStalkerRepository repository) : IRequestHandler<GetListOfLeadersOfGroupingQuery, List<Stalker>>
{
    public async Task<List<Stalker>> Handle(GetListOfLeadersOfGroupingQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetListOfLeadersOfGroupingsAsync();
    }
}

