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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();            
            return region;
        }

        public async Task<Region> DeleteAsync(Guid regionId)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(region => region.Id == regionId);

            if(region == null)
            {
                throw new NullReferenceException("Region not found.");
            }

            _context.Regions.Remove(region);
            var result = await _context.SaveChangesAsync();

            if(result <= 0)
            {
                throw new Exception("Unable to delete region.");
            }

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid regionId)
        {
            return await _context.Regions.FirstOrDefaultAsync(region => region.Id == regionId) ?? throw new NullReferenceException("Region not found.");
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var regionToUpdate = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException();

            regionToUpdate.Code = region.Code;
            regionToUpdate.Area = region.Area;
            regionToUpdate.Name = region.Name;
            regionToUpdate.Population = region.Population;
            regionToUpdate.Lat = region.Lat;
            regionToUpdate.Long = region.Long;

            await _context.SaveChangesAsync();            
            return regionToUpdate;
        }
    }
}
