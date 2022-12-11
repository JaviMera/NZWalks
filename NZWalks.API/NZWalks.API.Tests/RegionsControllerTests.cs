using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using NUnit.Framework;
using NZWalks.API.Controllers;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Profiles;
using NZWalks.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Tests
{
    public class RegionsControllerTests
    {
        private IMapper? _fakeMapper;
        private Mock<IRegionsRepository>? _mockRegionsRepository;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<RegionsProfile>();
            });

            _fakeMapper = config.CreateMapper();

            _mockRegionsRepository = new Mock<IRegionsRepository>();            
        }

        [TearDown]
        public void TearDown()
        {
            _fakeMapper = null;
            _mockRegionsRepository = null;
        }

        [Test]
        public async Task GetRegions_Returns200()
        {
            // Arrange
            var fakeRegions = CreateRegions();
            _mockRegionsRepository!.Setup(x => x.GetAllAsync())
                .ReturnsAsync(fakeRegions);

            var regionsController = new RegionsController(_mockRegionsRepository.Object, _fakeMapper!);

            // Act
            var result = await regionsController.GetAllRegionsAsync() as OkObjectResult;


            // Assert
            Assert.IsTrue(result!.StatusCode == 200, $"Code was {result.StatusCode}");
            Assert.IsTrue(result.Value is List<RegionDto>);

            var regions = result.Value as List<RegionDto>; 
            Assert.IsTrue(regions!.Count > 0);
         }

        [Test]
        public async Task GetRegions_WithEmptyList_Returns204()
        {
            // Arrange
            var fakeRegions = new List<Region>();

            _mockRegionsRepository!.Setup(x => x.GetAllAsync())
                .ReturnsAsync(fakeRegions);

            var regionsController = new RegionsController(_mockRegionsRepository.Object, _fakeMapper!);

            // Act
            var result = await regionsController.GetAllRegionsAsync();

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);

            var noContentResult = result as NoContentResult;
            Assert.IsTrue(noContentResult!.StatusCode == 204, $"Expected 204 Code was {noContentResult!.StatusCode}");           
        }

        [Test]
        public async Task GetRegionById_Returns200_WithRequestedRegion()
        {
            // Arrange            
            var fakeRegions = CreateRegions();
            var regionId = fakeRegions.Select(x => x.Id).FirstOrDefault();

            _mockRegionsRepository!.Setup(x => x.GetAsync(regionId))
                .ReturnsAsync(fakeRegions.FirstOrDefault());

            var regionsController = new RegionsController(_mockRegionsRepository.Object, _fakeMapper!);

            // Act
            var result = await regionsController.GetRegionAsync(regionId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            var regionResult = okResult!.Value as RegionDto;

            Assert.AreEqual(regionId, regionResult!.Id);
        }

        [Test]
        public async Task GetRegionById_IncorrectRegionId_Returns404()
        {
            // Arrange            
            var fakeRegions = CreateRegions();
            var regionIdFromList = fakeRegions.Select(x => x.Id).FirstOrDefault();

            // RegionId does not belong in regions list
            var regionId = Guid.NewGuid();

            _mockRegionsRepository!.Setup(x => x.GetAsync(regionIdFromList))
                .ReturnsAsync(fakeRegions.FirstOrDefault());

            var regionsController = new RegionsController(_mockRegionsRepository.Object, _fakeMapper!);

            // Act
            var result = await regionsController.GetRegionAsync(regionId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);

            var notFoundResult = result as NotFoundObjectResult;

            Assert.IsNotNull(notFoundResult);

            Assert.AreEqual(404, notFoundResult!.StatusCode);
            Assert.AreEqual("Region not found.", notFoundResult!.Value);
        }

        [Test]
        public async Task AddRegion_Returns201()
        {
            // Arrange
            var newRegionId = Guid.NewGuid();

            var newRegion = new Region
            {
                Area = 1,
                Code = "New",
                Id = newRegionId,
                Lat = 1,
                Long = 1,
                Name = "New Region",
                Population = 100,
            };

            var newRegionDto = new AddRegionDto
            {
                Area = 1,
                Code = "New",                
                Lat = 1,
                Long = 1,
                Name = "New Region",
                Population = 100,
            };

            _mockRegionsRepository!.Setup(x => x.AddAsync(It.IsAny<Region>()))
                .ReturnsAsync(newRegion);

            var regionsController = new RegionsController(_mockRegionsRepository.Object, _fakeMapper!);

            // Act
            var result = await regionsController.AddRegionAsync(newRegionDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedAtActionResult>(result);

            var createdAtActionResult = result as CreatedAtActionResult;

            Assert.IsTrue(createdAtActionResult!.StatusCode == 201);

            Assert.IsInstanceOf<RegionDto>(createdAtActionResult.Value);

            var regionDto = createdAtActionResult.Value as RegionDto;

            Assert.AreEqual(newRegionId, regionDto!.Id);
        }

        private List<Region> CreateRegions()
        {
            return new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Area = 10, Code = "ABCD", Lat = 12, Long = 12, Name = "Fake Region", Population = 10000
                }
            };
        }
    }
}