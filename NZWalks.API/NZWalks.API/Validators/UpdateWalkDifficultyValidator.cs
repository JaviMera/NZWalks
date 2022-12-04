using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public sealed class UpdateWalkDifficultyValidator : AbstractValidator<UpdateWalkDifficultyDto>
    {
        public UpdateWalkDifficultyValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
