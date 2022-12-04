using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public sealed class AddWalkDtoValidator : AbstractValidator<AddWalkDto>
    {
        public AddWalkDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
