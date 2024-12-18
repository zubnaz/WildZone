using Domain.Models.Entities;

namespace Application.Interfaces;

public interface IGroupingRepository
{
    Task<List<Grouping>> GetListOfGroupingAsync();
}
