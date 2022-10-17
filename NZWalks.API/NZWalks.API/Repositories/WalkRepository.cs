using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public sealed class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;
        public WalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _context.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).ToListAsync();
        }
    }
}
