using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public sealed class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDto>()
                .ReverseMap();
        }
    }
}
