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

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();

            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _context.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid walkId)
        {
            var walk = await _context.Walks
                .Include(x => x.WalkDifficulty)
                .Include(x => x.Region)
                .FirstOrDefaultAsync(x => x.Id == walkId) ?? throw new NullReferenceException("Walk not found.");

            return walk;
        }

        public async Task<Walk> UpdateWalkAsync(Guid walkId, Walk walk)
        {
            var walkToUpdate = await _context.Walks.FirstOrDefaultAsync(x => x.Id == walkId) ?? throw new NullReferenceException("Unable to find walk.");
            
            walkToUpdate.Length = walk.Length;
            walkToUpdate.Name = walk.Name;
            walkToUpdate.WalkDifficultyId = walk.WalkDifficultyId;
            walkToUpdate.RegionId = walk.RegionId;
            await _context.SaveChangesAsync();

            return walkToUpdate;
        }
    }
}
