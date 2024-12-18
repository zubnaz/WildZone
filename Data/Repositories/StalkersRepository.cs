using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;
public class StalkersRepository(StalkersDbContext context) : IStalkerRepository
{
    public async Task<List<Stalker>> GetListOfLeadersOfGroupingsAsync()
    {
       return await context.Users.Where(stl => stl.IsLeader)
            .Include(s => s.Group)
            .Include(s => s.Rang)
            .Include(s => s.Avatar)
            .ToListAsync();
    }
    public async Task<Guid> GetInitialRangAsync()
    {
        return (await context.Rangs.OrderBy(r => r.Power).FirstAsync()).Id;
    }
}

