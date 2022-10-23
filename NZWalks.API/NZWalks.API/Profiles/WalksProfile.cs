using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public sealed class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalkDto>()
                .ReverseMap()
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.WalkDifficulty, options => options.Ignore())
                .ForMember(x => x.Region, options => options.Ignore());

            CreateMap<WalkDifficulty, WalkDifficultyDto>()
                .ReverseMap();

            CreateMap<Walk, AddWalkDto>()
                .ReverseMap()
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.WalkDifficulty, options => options.Ignore())
                .ForMember(x => x.Region, options => options.Ignore());

            CreateMap<Walk, UpdateWalkDto>()
                .ReverseMap()
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.WalkDifficulty, options => options.Ignore())
                .ForMember(x => x.Region, options => options.Ignore());
        }
    }
}
