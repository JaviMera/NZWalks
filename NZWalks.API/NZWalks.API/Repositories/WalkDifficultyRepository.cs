using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public sealed class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkDifficultyRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty walkDifficulty)
        {
            var newGuid = Guid.NewGuid();
            walkDifficulty.Id = newGuid;
            await _context.AddAsync(walkDifficulty);
            await _context.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _context.WalksDifficulty.ToListAsync();
        }
    }
}
