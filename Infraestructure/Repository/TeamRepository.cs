using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public class TeamRepository : GenericRepository<Team>, ITeam
{
    private readonly DbFirstContext _context;
    public TeamRepository(DbFirstContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
            .ToListAsync();
    }

    public override async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}