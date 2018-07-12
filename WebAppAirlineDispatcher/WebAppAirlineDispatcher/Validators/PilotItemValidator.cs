using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class PilotItemValidator : AbstractValidator<PilotItem>
    {
        public PilotItemValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Pilot id can't be empty !");
            RuleFor(p => p.FirstName).NotNull().WithMessage("First name can't be null !");
            RuleFor(p => p.LastName).NotNull().WithMessage("Last name  can't be null !");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("Birthdate can't be empty !");
            RuleFor(p => p.Experience).NotEmpty().WithMessage("Experience can't be empty !");

        }
    }
}
