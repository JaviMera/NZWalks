using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public sealed class AddRegionDtoValidator : AbstractValidator<AddRegionDto>
    {
        public AddRegionDtoValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);            
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
