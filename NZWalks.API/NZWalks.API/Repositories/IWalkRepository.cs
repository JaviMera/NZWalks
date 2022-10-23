using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetAsync(Guid walkId);
        Task<Walk> AddWalkAsync(Walk walk);
        Task<Walk> UpdateWalkAsync(Guid walkId, Walk walk);
    }
}
