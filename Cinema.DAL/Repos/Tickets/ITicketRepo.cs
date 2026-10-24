using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Tickets
{
    public interface ITicketRepo
    {
        IEnumerable<Ticket> GetTickets();
        Ticket GetTicket(int id);
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        int SaveChanges();
    }
}
