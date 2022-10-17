using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionsRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid regionId);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid regionId);
    }
}
