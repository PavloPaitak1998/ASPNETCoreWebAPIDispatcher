﻿using AutoMapper;
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
    public class DepartureService : IDepartureService
    {
        IUnitOfWork unitOfWork;

        public DepartureService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public DepartureDTO GetDeparture(int id)
        {
            var departure = unitOfWork.Departures.Get(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            return new DepartureDTO
            {
                Id = departure.Id,
                FlightNumber = departure.FlightNumber,
                CrewId = departure.CrewId,
                PlaneId = departure.PlaneId,
                Time = departure.Time
            };
        }

        public IEnumerable<DepartureDTO> GetDepartures()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Departure, DepartureDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Departure>, List<DepartureDTO>>(unitOfWork.Departures.GetAll());
        }

        public void CreateDeparture(DepartureDTO departureDTO)
        {
            if (unitOfWork.Departures.Get(departureDTO.Id) != null)
                throw new ValidationException($"Departure with this id {departureDTO.Id} already exist");

            var crew = unitOfWork.Crew.Get(departureDTO.CrewId);
            if (crew == null)
                throw new ValidationException($"Crew with this id {departureDTO.CrewId} not found");

            var flight = unitOfWork.Flights.Get(departureDTO.FlightNumber);
            if (flight == null)
                throw new ValidationException($"Flight with this number {departureDTO.FlightNumber} not found");

            var plane = unitOfWork.Planes.Get(departureDTO.PlaneId);
            if (plane == null)
                throw new ValidationException($"Plane with this id {departureDTO.PlaneId} not found");


            Departure departure = new Departure
            {
                Id=departureDTO.Id,
                FlightNumber=departureDTO.FlightNumber,
                CrewId=departureDTO.CrewId,
                PlaneId=departureDTO.PlaneId,
                Time=departureDTO.Time
            };

            unitOfWork.Departures.Create(departure);
        }

        public void UpdateDeparture(DepartureDTO departureDTO)
        {
            var departure = unitOfWork.Departures.Get(departureDTO.Id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {departureDTO.Id} not found");

            unitOfWork.Departures.Update(new Departure
            {
                Id = departureDTO.Id,
                FlightNumber = departureDTO.FlightNumber,
                CrewId = departureDTO.CrewId,
                PlaneId = departureDTO.PlaneId,
                Time = departureDTO.Time
            });
        }

        public void DeleteAllDepartures()
        {
            unitOfWork.Departures.DeleteAll();
        }

        public void DeleteDeparture(int id)
        {
            var departure = unitOfWork.Departures.Get(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            unitOfWork.Departures.Delete(id);
        }
    }
}