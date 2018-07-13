using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class TicketDTOValidator : AbstractValidator<TicketDTO>
    {
        public TicketDTOValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Ticket id can't be empty !").GreaterThan(0);
            RuleFor(t => t.Price).NotEmpty().WithMessage("Price can't be empty !").GreaterThan(0);

        }
    }
}
