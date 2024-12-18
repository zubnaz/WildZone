using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AvatarRepository(StalkersDbContext context) : IAvatarRepository
{
    private readonly DbSet<Avatar> dbSet = context.Avatars;

    public async Task<List<Avatar>> GetListOfAvatarsByGroupingIdAsync(Guid groupingId)
    {
        return await dbSet.Where(a => a.GroupingId == groupingId).ToListAsync();
    }
}
