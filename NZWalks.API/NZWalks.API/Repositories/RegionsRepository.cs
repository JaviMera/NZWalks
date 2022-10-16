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
            return await _context.Regions.ToListAsync();
        }
    }
}
