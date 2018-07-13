using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class CrewDTOValidator : AbstractValidator<CrewDTO>
    {
        public CrewDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Crew id can't be empty !").GreaterThan(0);
            RuleFor(c => c.PilotId).NotEmpty().WithMessage("Pilot id can't be empty !").GreaterThan(0);
            RuleFor(c => c.StewardessesId).NotEmpty().WithMessage("Stewardesses Id  can't be empty !");
        }

    }
}
