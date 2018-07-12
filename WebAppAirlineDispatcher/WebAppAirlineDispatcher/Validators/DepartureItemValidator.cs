using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class DepartureItemValidator : AbstractValidator<DepartureItem>
    {
        public DepartureItemValidator()
        {
            RuleFor(d => d.Id).NotEmpty().WithMessage("Departure id can't be empty !");
            RuleFor(d => d.Time).NotEmpty().WithMessage("Time can't be empty !");
            RuleFor(d => d.CrewId).NotEmpty().WithMessage("Crew Id  can't be empty !");
            RuleFor(d => d.PlaneId).NotEmpty().WithMessage("Plane Id can't be empty !");
            RuleFor(d => d.FlightNumber).NotEmpty().WithMessage("Flight Number can't be empty !");

        }
    }
}
