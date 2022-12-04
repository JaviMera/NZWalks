using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public sealed class AddWalkDifficultyValidator : AbstractValidator<AddWalktDifficultyDto>
    {
        public AddWalkDifficultyValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
