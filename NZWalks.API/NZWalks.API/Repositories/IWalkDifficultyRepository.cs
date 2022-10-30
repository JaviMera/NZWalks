using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
    }

    public sealed class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkDifficultyRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _context.WalksDifficulty.ToListAsync();
        }
    }
}
