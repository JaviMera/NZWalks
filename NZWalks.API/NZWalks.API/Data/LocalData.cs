using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public static class LocalData
    {
        public static IList<Region> GetRegions()
        {
            return new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "NRTHL",
                    Name = "Northland Region",
                    Area = 13789,
                    Lat = -35.3708304,
                    Long = 172.5717825,
                    Population = 194600
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "AUCK",
                    Name = "Auckland Region",
                    Area = 4894,
                    Lat = -36.5253207,
                    Long = 173.7785704,
                    Population = 1718982
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "WAIK",
                    Name = "Waikato Region",
                    Area = 8970,
                    Lat = -37.5144584,
                    Long = 174.5405128,
                    Population = 496700
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "BAYP",
                    Name = "Bay of Plenty Region",
                    Area = 12230,
                    Lat = -37.5328259,
                    Long = 175.7642701,
                    Population = 345400
                }
            };
        }
        public static IList<WalkDifficulty> GetWalkDifficulties()
        {
            return new List<WalkDifficulty>
            {
                new WalkDifficulty { Id = Guid.NewGuid(), Code = "Easy" },
                new WalkDifficulty { Id = Guid.NewGuid(), Code = "Medium" },
                new WalkDifficulty { Id = Guid.NewGuid(), Code = "Hard" },
            };
        }
        public static IEnumerable<Walk> GetWalks(IEnumerable<Region> regions, IEnumerable<WalkDifficulty> walkDifficulties)
        {            
            var northLandRegion = regions.FirstOrDefault(region => region.Code.Equals("NRTHL"));
            var aucklandRegion = regions.FirstOrDefault(region => region.Code.Equals("AUCK"));
            var waikatoRegion = regions.FirstOrDefault(region => region.Code.Equals("WAIK"));
            var bayOfPlentRegion = regions.FirstOrDefault(region => region.Code.Equals("BAYP"));

            var easy = walkDifficulties.FirstOrDefault(difficulty => difficulty.Code.Equals("Easy"));
            var medium = walkDifficulties.FirstOrDefault(difficulty => difficulty.Code.Equals("Medium"));
            var hard = walkDifficulties.FirstOrDefault(difficulty => difficulty.Code.Equals("Hard"));

            return new List<Walk>
            {
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Waiotemarama Loop Track",
                    Length = 1.5,
                    WalkDifficultyId = medium!.Id,
                    RegionId = northLandRegion!.Id
                },
                 new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Mt Eden Volcano Walk",
                    Length = 2,
                    WalkDifficultyId = easy!.Id,
                    RegionId = aucklandRegion!.Id
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "One Tree Hill Walk",
                    Length = 3.5,
                    WalkDifficultyId = easy!.Id,
                    RegionId = aucklandRegion!.Id
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Lonely Bay",
                    Length = 1.2,
                    WalkDifficultyId = easy!.Id,
                    RegionId = waikatoRegion!.Id
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Mt Te Aroha To Wharawhara Track Walk",
                    Length = 32,
                    WalkDifficultyId = hard!.Id,
                    RegionId = bayOfPlentRegion!.Id
                },
                new Walk
                {
                    Id = Guid.NewGuid(),
                    Name = "Rainbow Mountain Reserve Walk",
                    Length = 3.5,
                    WalkDifficultyId = hard!.Id,
                    RegionId = bayOfPlentRegion!.Id
                }
            };
        }
    }
}
