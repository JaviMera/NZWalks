using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using System.Xml;

namespace NZWalks.API.Data
{
    public sealed class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalksDifficulty { get; set; }
    }
}
