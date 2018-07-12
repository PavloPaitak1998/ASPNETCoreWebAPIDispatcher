using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class StewardessItemValidator : AbstractValidator<StewardessItem>
    {
        public StewardessItemValidator()
        {
            RuleFor(s => s.Id).NotEmpty().WithMessage("Stewardess id can't be empty !").GreaterThan(0);
            RuleFor(s => s.FirstName).NotNull().WithMessage("First name can't be null !");
            RuleFor(s => s.LastName).NotNull().WithMessage("Last name  can't be null !");
            RuleFor(s => s.BirthDate).NotEmpty().WithMessage("Birthdate can't be empty !");
        }
    }
}
