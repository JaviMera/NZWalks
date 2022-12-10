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
using System.Threading.Tasks;

namespace NZWalks.API.Tests
{
    public class RegionsControllerTests
    {
        private IMapper _fakeMapper;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<RegionsProfile>();
            });

            _fakeMapper = config.CreateMapper();
        }

        [Test]
        public async Task GetRegions_Returns200()
        {
            // Arrange
            var fakeRegions = CreateRegions();

            var mockRegionsRepository = new Mock<IRegionsRepository>();
            mockRegionsRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(fakeRegions);

            var regionsController = new RegionsController(mockRegionsRepository.Object, _fakeMapper);

            // Act
            var result = await regionsController.GetAllRegionsAsync() as OkObjectResult;


            // Assert
            Assert.IsTrue(result!.StatusCode == 200, $"Code was {result.StatusCode}");
            Assert.IsTrue(result.Value is List<RegionDto>);

            var regions = result.Value as List<RegionDto>; 
            Assert.IsTrue(regions!.Count > 0);
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