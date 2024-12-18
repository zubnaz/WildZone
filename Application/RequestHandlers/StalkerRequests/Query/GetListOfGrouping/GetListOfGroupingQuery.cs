using Domain.Models.Entities;
using ErrorOr;
using MediatR;

namespace Application.RequestHandlers.StalkerRequests.Query.GetListOfGrouping;

public class GetListOfGroupingQuery : IRequest<ErrorOr<List<Grouping>>>;
