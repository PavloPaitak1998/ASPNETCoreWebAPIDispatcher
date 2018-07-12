using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class CrewItemValidator : AbstractValidator<CrewItem>
    {
        public CrewItemValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Crew id can't be empty !").GreaterThan(0);
            RuleFor(c => c.PilotId).NotEmpty().WithMessage("Pilot id can't be empty !").GreaterThan(0);
            RuleFor(c => c.StewardessesId).NotEmpty().WithMessage("Stewardesses Id  can't be empty !");
        }
    }
}
