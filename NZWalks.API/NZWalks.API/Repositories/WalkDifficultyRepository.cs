using Microsoft.EntityFrameworkCore;
using NZWalks.API.Controllers;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

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

        public async Task<WalkDifficulty> DeleteWalkDifficultyAsync(Guid walkDifficultyId)
        {
            var walkDifficultyToDelete = await _context.WalksDifficulty.FirstOrDefaultAsync(x => x.Id == walkDifficultyId);

            if(walkDifficultyToDelete == null)
            {
                throw new NullReferenceException("Unable to find Walk Difficulty.");
            }

            _context.Remove(walkDifficultyToDelete);
            await _context.SaveChangesAsync();
            return walkDifficultyToDelete;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _context.WalksDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetWalkDifficultyAsync(Guid walkDifficultyId)
        {
            return await _context.WalksDifficulty.FirstOrDefaultAsync(x => x.Id == walkDifficultyId);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid walkDifficultyId, WalkDifficulty walkDifficulty)
        {
            var walkDifficultyToUpdate = await _context.WalksDifficulty.FirstOrDefaultAsync(x => x.Id == walkDifficultyId);

            if(walkDifficultyToUpdate == null)
            {
                throw new NullReferenceException("Walk Difficulty not found.");
            }

            walkDifficultyToUpdate.Code = walkDifficulty.Code;
            await _context.SaveChangesAsync();
            return walkDifficultyToUpdate;
        }
    }
}
