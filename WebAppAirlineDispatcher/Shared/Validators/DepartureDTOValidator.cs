using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class DepartureDTOValidator : AbstractValidator<DepartureDTO>
    {
        public DepartureDTOValidator()
        {
            RuleFor(d => d.Id).NotEmpty().WithMessage("Departure id can't be empty !").GreaterThan(0);
            RuleFor(d => d.Time).NotEmpty().WithMessage("Time can't be empty !");
            RuleFor(d => d.CrewId).NotEmpty().WithMessage("Crew Id  can't be empty !");
            RuleFor(d => d.PlaneId).NotEmpty().WithMessage("Plane Id can't be empty !");
            RuleFor(d => d.FlightNumber).NotEmpty().WithMessage("Flight Number can't be empty !");

        }
    }
}
