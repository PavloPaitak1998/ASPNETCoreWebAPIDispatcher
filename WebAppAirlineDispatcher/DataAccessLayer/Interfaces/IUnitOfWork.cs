using DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Flight> Flights { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Departure> Departures { get; }
        IRepository<Stewardess> Stewardesses { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Crew> Crew { get; }
        IRepository<Plane> Planes { get; }
        IRepository<PlaneType> PlaneTypes { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
