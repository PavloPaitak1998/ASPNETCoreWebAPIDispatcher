﻿using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class TicketService : IEntityService<TicketDTO>
    {
        IUnitOfWork unitOfWork;

        public TicketService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public TicketDTO GetEntity(int id)
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

        public IEnumerable<TicketDTO> GetEntities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(unitOfWork.Tickets.GetAll());
        }

        public void CreateEntity(TicketDTO ticketDTO)
        {
            if (unitOfWork.Tickets.Get(ticketDTO.Id) != null)
                throw new ValidationException($"Ticket with this id {ticketDTO.Id} already exist");

            if(ticketDTO.FlightNumber!=null)
            {
                var flight = unitOfWork.Flights.Get(ticketDTO.FlightNumber.Value);
                if(flight==null)
                    throw new ValidationException($"Flight number {ticketDTO.FlightNumber.Value} not exist");
            }

            Ticket ticket = new Ticket
            {
                Id = ticketDTO.Id,
                FlightNumber = ticketDTO.FlightNumber,
                Price = ticketDTO.Price
            };

            unitOfWork.Tickets.Create(ticket);

        }

        public void UpdateEntity(TicketDTO ticketDTO)
        {
            var ticket = unitOfWork.Tickets.Get(ticketDTO.Id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {ticketDTO.Id} not found");

            if (ticketDTO.FlightNumber != null)
            {
                var flight = unitOfWork.Flights.Get(ticketDTO.FlightNumber.Value);
                if (flight == null)
                    throw new ValidationException($"Flight number {ticketDTO.FlightNumber.Value} not exist");
            }


            unitOfWork.Tickets.Update(new Ticket
            {
                Id = ticketDTO.Id,
                FlightNumber = ticketDTO.FlightNumber,
                Price = ticketDTO.Price
            });

        }

        public void DeleteAllEntities()
        {
            unitOfWork.Tickets.DeleteAll();
            foreach (var flight in unitOfWork.Flights.GetAll())
            {
                flight.TicketsId=new List<int>();
            }

        }

        public void DeleteEntity(int id)
        {
            var ticket = unitOfWork.Tickets.Get(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");

            unitOfWork.Tickets.Delete(ticket);

            foreach (var flight in unitOfWork.Flights.Find(f => f.TicketsId.Exists(t => t == id)))
            {
                flight.TicketsId.Remove(id);
            }
        }
    }
}
