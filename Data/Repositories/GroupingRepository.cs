using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class GroupingRepository(StalkersDbContext context) : IGroupingRepository
{
    private readonly DbSet<Grouping> dbSet = context.Grouping;
    public async Task<List<Grouping>> GetListOfGroupingAsync()
    {
        return await dbSet.ToListAsync();
    }
}
