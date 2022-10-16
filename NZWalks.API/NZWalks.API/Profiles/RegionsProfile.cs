using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public sealed class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
            
            CreateMap<Region, AddRegionDto>()                
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
