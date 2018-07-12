using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class PlaneTypeItemValidator : AbstractValidator<PlaneTypeItem>
    {
        public PlaneTypeItemValidator()
        {
            RuleFor(pt => pt.Id).NotEmpty().WithMessage("Plane type id can't be empty !").GreaterThan(0);
            RuleFor(pt => pt.Model).NotNull().WithMessage("Model can't be null !");
            RuleFor(pt => pt.Seats).NotEmpty().WithMessage("Seats  can't be empty !").GreaterThan(0);
            RuleFor(pt => pt.Carrying).NotEmpty().WithMessage("Carryingcan't be empty !").GreaterThan(0);
        }
    }
}
