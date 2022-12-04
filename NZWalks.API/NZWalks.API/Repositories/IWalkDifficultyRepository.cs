using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetWalkDifficultyAsync(Guid walkDifficultyId);
        Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> DeleteWalkDifficultyAsync(Guid walkDifficultyId);
        Task<WalkDifficulty> UpdateAsync(Guid walkDifficultyId, WalkDifficulty walkDifficulty);
    }
}
