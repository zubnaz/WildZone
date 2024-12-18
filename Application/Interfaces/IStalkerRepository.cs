using Domain.Models.Entities;

namespace Application.Interfaces;
public interface IStalkerRepository
{
    Task<List<Stalker>> GetListOfLeadersOfGroupingsAsync();
    Task<Guid> GetInitialRangAsync();
    
}

