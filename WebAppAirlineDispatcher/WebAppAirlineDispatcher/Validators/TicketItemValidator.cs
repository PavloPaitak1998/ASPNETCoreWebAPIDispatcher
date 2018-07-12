using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class TicketItemValidator : AbstractValidator<TicketItem>
    {
        public TicketItemValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Ticket id can't be empty !").GreaterThan(0);
            RuleFor(t => t.Price).NotEmpty().WithMessage("Price can't be empty !").GreaterThan(0);
        }

    }
}
