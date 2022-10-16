using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public sealed class RegionsRepository : IRegionsRepository
    {
        private readonly NZWalksDbContext _context;

        public RegionsRepository(NZWalksDbContext context)
        {
            _context = context; ;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync() ?? throw new NullReferenceException("Regions not found.");
        }

        public async Task<Region> GetAsync(Guid regionId)
        {
            return await _context.Regions.FirstOrDefaultAsync(region => region.Id == regionId) ?? throw new NullReferenceException("Region not found.");
        }
    }
}
