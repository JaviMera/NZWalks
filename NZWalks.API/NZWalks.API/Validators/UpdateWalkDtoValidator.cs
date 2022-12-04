using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public sealed class UpdateWalkDtoValidator : AbstractValidator<UpdateWalkDto>
    {
        public UpdateWalkDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
