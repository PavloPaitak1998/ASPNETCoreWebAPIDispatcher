using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork unitOfWork;

        public TicketService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public TicketDTO GetTicket(int id)
        {
            var ticket = unitOfWork.Tickets.Get(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");

            return new TicketDTO
            {
                Id=ticket.Id,
                FlightNumber=ticket.FlightNumber,
                Price=ticket.Price
            };
        }

        public IEnumerable<TicketDTO> GetTickets()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(unitOfWork.Tickets.GetAll());
        }

        public void CreateTicket(TicketDTO ticketDTO)
        {
            if (unitOfWork.Flights.Get(ticketDTO.Id) != null)
            {
                throw new ValidationException($"Ticket with this id {ticketDTO.Id} already exist");
            }

            Ticket ticket = new Ticket
            {
                Id = ticketDTO.Id,
                FlightNumber = ticketDTO.FlightNumber,
                Price = ticketDTO.Price
            };

            unitOfWork.Tickets.Create(ticket);

        }

        public void UpdateTicket(TicketDTO ticketDTO)
        {
            var ticket = unitOfWork.Tickets.Get(ticketDTO.Id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {ticketDTO.Id} not found");

            unitOfWork.Tickets.Update(new Ticket
            {
                Id = ticketDTO.Id,
                FlightNumber = ticketDTO.FlightNumber,
                Price = ticketDTO.Price
            });

        }

        public void DeleteAllTickets()
        {
            unitOfWork.Tickets.DeleteAll();
        }

        public void DeleteTicket(int id)
        {
            var ticket = unitOfWork.Tickets.Get(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");

            unitOfWork.Tickets.Delete(id);
        }
    }
}
