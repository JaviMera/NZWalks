using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Tests
{
    public class RegionsRepositoryTests
    {        
        private IRegionsRepository? _regionsRepository;
        private NZWalksDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var dbname = $"NZWalksDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<NZWalksDbContext>()
                .UseInMemoryDatabase(dbname)
                .Options;

            _dbContext = new NZWalksDbContext(dbContextOptions);            
            _regionsRepository = new RegionsRepository(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
            _regionsRepository = null;
        }

        [Test]
        public async Task AddAsync()
        {
            // Arrange
            Guid newRegionId = Guid.NewGuid();
            var newRegion = new Region
            {
                Id = newRegionId,
                Name = "Region",
                Code = "ABCD",
                Population = 1,
                Lat = 1,
                Long = 1,
                Area = 1
            };
            // Act

            var result = await _regionsRepository!.AddAsync(newRegion);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newRegionId, result.Id);

            var region = await _regionsRepository.GetAsync(newRegionId);
            Assert.IsNotNull(region);
            Assert.AreEqual(newRegionId, region!.Id);
         }

        [Test]
        public async Task GetAllAsync()
        {
            // Arrange
            var regions = new List<Region>
            {
                new Region
                {
                    Id=Guid.NewGuid(),
                },
                new Region
                {
                    Id=Guid.NewGuid(),
                },
            };

            regions.ForEach(async x => await _regionsRepository!.AddAsync(x));

            // Act            
            var regionList = await _regionsRepository!.GetAllAsync();

            // Assert
            Assert.IsNotNull(regionList);
            Assert.IsTrue(regionList.Count() == 2);
        }

        [Test]
        public async Task UpdateAsync()
        {
            // Arrange
            Guid newRegionId = Guid.NewGuid();
            var newRegion = new Region
            {
                Id = newRegionId,
                Name = "Region",
                Code = "ABCD",
                Population = 1,
                Lat = 1,
                Long = 1,
                Area = 1
            };

            await _regionsRepository!.AddAsync(newRegion);

            // Act            
            var updatedRegion = new Region
            {                
                Name = "Updated Region",
                Code = "EFGH",
                Population = 10,
                Lat = 10,
                Long = 10,
                Area = 10
            };

            var result = await _regionsRepository.UpdateAsync(newRegionId, updatedRegion);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Region", result.Name);
            Assert.AreEqual("EFGH", result.Code);
            Assert.AreEqual(10, result.Population);
            Assert.AreEqual(10, result.Lat);
            Assert.AreEqual(10, result.Lat);
            Assert.AreEqual(10, result.Area);
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            Guid newRegionId = Guid.NewGuid();
            var newRegion = new Region
            {
                Id = newRegionId,
                Name = "Region",
                Code = "ABCD",
                Population = 1,
                Lat = 1,
                Long = 1,
                Area = 1
            };
            
            await _regionsRepository!.AddAsync(newRegion);

            // Act            
            var result = await _regionsRepository.DeleteAsync(newRegionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newRegionId, result.Id);

            var regionList = await _regionsRepository.GetAllAsync();
            Assert.AreEqual(0, regionList.Count());
        }
    }
}