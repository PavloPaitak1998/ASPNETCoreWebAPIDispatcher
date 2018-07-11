using DataAccessLayer.Implementation.Repositories;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        readonly IDataSource dataSource;

        FlightRepository flightRepository;
        TicketRepository ticketRepository;
        DepartureRepository departureRepository;
        StewardessRepository stewardessRepository;
        PilotRepository pilotRepository;
        CrewRepository crewRepository;
        PlaneRepository planeRepository;
        PlaneTypeRepository planeTypeRepository;

        public UnitOfWork(IDataSource data)
        {
            dataSource = data;
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(dataSource);
                return flightRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(dataSource);
                return ticketRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository(dataSource);
                return departureRepository;
            }
        }

        public IRepository<Stewardess> Stewardesses
        {
            get
            {
                if (stewardessRepository == null)
                    stewardessRepository = new StewardessRepository(dataSource);
                return stewardessRepository;
            }
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository(dataSource);
                return pilotRepository;
            }
        }

        public IRepository<Crew> Crew
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new CrewRepository(dataSource);
                return crewRepository;
            }
        }

        public IRepository<Plane> Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository(dataSource);
                return planeRepository;
            }
        }

        public IRepository<PlaneType> PlaneTypes
        {
            get
            {
                if (planeTypeRepository == null)
                    planeTypeRepository = new PlaneTypeRepository(dataSource);
                return planeTypeRepository;
            }
        }


        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
