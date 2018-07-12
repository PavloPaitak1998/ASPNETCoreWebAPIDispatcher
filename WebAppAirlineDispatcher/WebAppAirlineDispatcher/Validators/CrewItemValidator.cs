using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class CrewItemValidator : AbstractValidator<CrewItem>
    {
        public CrewItemValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Crew id can't be empty !");
            RuleFor(c => c.PilotId).NotEmpty().WithMessage("Pilot id can't be empty !");
            RuleFor(c => c.StewardessesId).NotNull().WithMessage("Stewardesses Id  can't be null !");
        }
    }
}
