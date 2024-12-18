using Domain.Models.Entities;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfLeadersOfGroupings;
public record GetListOfLeadersOfGroupingQuery : IRequest<List<Stalker>>;

