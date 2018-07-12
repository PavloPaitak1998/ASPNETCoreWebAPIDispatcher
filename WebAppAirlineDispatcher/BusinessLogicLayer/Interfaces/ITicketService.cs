using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        TicketDTO GetTicket(int id);
        IEnumerable<TicketDTO> GetTickets();
        void CreateTicket(TicketDTO ticketDTO);
        void UpdateTicket(TicketDTO ticketDTO);
        void DeleteTicket(int id);
        void DeleteAllTickets();
    }
}
