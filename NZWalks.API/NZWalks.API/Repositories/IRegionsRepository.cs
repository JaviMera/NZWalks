using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionsRepository
    {
        IEnumerable<Region> GetAll();
    }

    public sealed class RegionsRepository : IRegionsRepository
    {
        private readonly NZWalksDbContext _context;

        public RegionsRepository(NZWalksDbContext context)
        {
            _context = context; ;
        }

        public IEnumerable<Region> GetAll()
        {
            return _context.Regions.ToList();
        }
    }
}
