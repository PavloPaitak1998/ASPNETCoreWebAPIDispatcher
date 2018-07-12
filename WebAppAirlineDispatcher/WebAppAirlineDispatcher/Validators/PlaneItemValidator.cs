using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class PlaneItemValidator : AbstractValidator<PlaneItem>
    {
        public PlaneItemValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Flight Id can't be empty !");
            RuleFor(p => p.Name).NotNull().WithMessage("Name can't be null !");
            RuleFor(p => p.TypeId).NotEmpty().WithMessage("Type Id  can't be empty !");
            RuleFor(p => p.ReleaseDate).NotEmpty().WithMessage("Release Date can't be empty !");
            RuleFor(p => p.Lifetime).NotEmpty().WithMessage("Lifetime can't be empty !");
        }
    }
}
