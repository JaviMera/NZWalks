namespace NZWalks.API.Models.Domain
{
    public sealed class Walk {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        // Navigation Properties
        public Region Region { get; set; } = new Region();
        public WalkDifficulty WalkDifficulty { get; set; } = new WalkDifficulty();
    }
}
