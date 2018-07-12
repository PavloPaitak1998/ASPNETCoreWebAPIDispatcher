﻿using FluentValidation;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Validators
{
    public class FlightItemValidator : AbstractValidator<FlightItem>
    {
        public FlightItemValidator()
        {
            RuleFor(f => f.Number).NotEmpty().WithMessage("Flight number can't be empty !");
            RuleFor(f => f.PointOfDeparture).NotNull().WithMessage("Point of departure can't be null !");
            RuleFor(f => f.DepartureTime).NotEmpty().WithMessage("Departure time  can't be empty !");
            RuleFor(f => f.Destination).NotNull().WithMessage("Destination can't be empty !");
            RuleFor(f => f.DestinationTime).NotEmpty().WithMessage("Destination time can't be null !");
            RuleFor(f => f.TicketsId).NotNull().WithMessage("Tickets Id can't be null !");
        }
    }
}
