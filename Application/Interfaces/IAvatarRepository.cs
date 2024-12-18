using Domain.Models.Entities;

namespace Application.Interfaces;

public interface IAvatarRepository
{
    Task<List<Avatar>> GetListOfAvatarsByGroupingIdAsync(Guid groupingId);
}
