using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public sealed class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        public RegionDto Region { get; set; } = new RegionDto();
        public WalkDifficultyDto WalkDifficulty { get; set; } = new WalkDifficultyDto();
    }
}
