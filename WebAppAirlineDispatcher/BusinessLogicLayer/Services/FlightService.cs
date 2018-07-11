using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Services
{
    public class FlightService:IFlightService
    {
        IUnitOfWork unitOfWork;

        public FlightService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public FlightDTO GetFlight(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set flight number ");

            var flight = unitOfWork.Flights.Get(id.Value);

            if (flight == null)
                throw new ValidationException($"Flight with this number {id.Value} not found");

            return new FlightDTO
            {
                Number = flight.Number,
                PointOfDeparture = flight.PointOfDeparture,
                DepartureTime = flight.DepartureTime,
                Destination = flight.Destination,
                DestinationTime = flight.DestinationTime,
                TicketsId = flight.TicketsId
            };

        }

        public IEnumerable<FlightDTO> GetFlights()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Flight, FlightDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(unitOfWork.Flights.GetAll());
        }

        public void CreateFlight(FlightDTO flightDTO)
        {
            List<Ticket> tickets = new List<Ticket>();

            int count = 0;
            foreach (var ticketId in flightDTO.TicketsId)
            {
                tickets.Add(unitOfWork.Tickets.Get(ticketId));
                if (tickets[count] == null)
                    throw new ValidationException($"Ticket with this id{ticketId} not found");
                count++;
            }

            Flight flight = new Flight
            {
                Number = flightDTO.Number,
                PointOfDeparture = flightDTO.PointOfDeparture,
                DepartureTime = flightDTO.DepartureTime,
                Destination = flightDTO.Destination,
                DestinationTime = flightDTO.DestinationTime,
                TicketsId = flightDTO.TicketsId
            };

            unitOfWork.Flights.Create(flight);
        }

        public void UpdateFlight(FlightDTO flightDTO)
        {
            var flight = unitOfWork.Flights.Get(flightDTO.Number);

            if (flight == null)
                throw new ValidationException($"Flight with this number {flightDTO.Number} not found");

            unitOfWork.Flights.Update(new Flight
            {
                PointOfDeparture = flightDTO.PointOfDeparture,
                DepartureTime = flightDTO.DepartureTime,
                Destination = flightDTO.Destination,
                DestinationTime = flightDTO.DestinationTime,
                TicketsId = flightDTO.TicketsId
            });
        }

        public void DeleteAllFlights()
        {
            unitOfWork.Flights.DeleteAll();
        }

        public void DeleteFlight(int? id)
        {
            if(id==null)
                throw new ValidationException("Not set flight id ");

            var flight = unitOfWork.Flights.Get(id.Value);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id.Value} not found");

            unitOfWork.Flights.Delete(id.Value);
        }
    }
}
