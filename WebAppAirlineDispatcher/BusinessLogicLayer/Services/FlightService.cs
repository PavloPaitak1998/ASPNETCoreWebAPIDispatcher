using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class FlightService:IFlightService
    {
        IUnitOfWork unitOfWork;

        public FlightService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public FlightDTO GetFlight(int id)
        {
            var flight = unitOfWork.Flights.Get(id);

            if (flight == null)
                throw new ValidationException($"Flight with this number {id} not found");

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
            if (unitOfWork.Flights.Get(flightDTO.Number)!=null)
                throw new ValidationException($"Flight with this number {flightDTO.Number} already exist");

            List<Ticket> tickets = new List<Ticket>();

            int count = 0;
            foreach (var ticketId in flightDTO.TicketsId)
            {
                tickets.Add(unitOfWork.Tickets.Get(ticketId));
                if (tickets[count] == null)
                    throw new ValidationException($"Ticket with this id {ticketId} not found");
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

            if(flightDTO.TicketsId.Count()>0)
            {
                List<Ticket> tickets = new List<Ticket>();

                int count = 0;
                foreach (var ticketId in flightDTO.TicketsId)
                {
                    tickets.Add(unitOfWork.Tickets.Get(ticketId));
                    if (tickets[count] == null)
                        throw new ValidationException($"Ticket with this id {ticketId} not found");
                    count++;
                }

            }

            unitOfWork.Flights.Update(new Flight
            {
                Number= flightDTO.Number,
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

            foreach (var departure in unitOfWork.Departures.GetAll())
            {
                departure.FlightNumber = 0;
            }
            foreach (var ticket in unitOfWork.Tickets.GetAll())
            {
                ticket.FlightNumber = 0;
            }


        }

        public void DeleteFlight(int id)
        {
            var flight = unitOfWork.Flights.Get(id);

            if (flight == null)
                throw new ValidationException($"Flight with this number {id} not found");

            unitOfWork.Flights.Delete(flight);

            foreach (var departure in unitOfWork.Departures.Find(d => d.FlightNumber == id))
            {
                departure.FlightNumber = 0;
            }
            foreach (var ticket in unitOfWork.Tickets.Find(t => t.FlightNumber == id))
            {
                ticket.FlightNumber = 0;
            }
        }
    }
}
