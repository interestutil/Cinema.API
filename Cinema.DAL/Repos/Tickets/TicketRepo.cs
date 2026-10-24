using Cinema.DAL.Data;
using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Tickets
{
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationContext _applicationContext;
        public TicketRepo(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void AddTicket(Ticket ticket)
        {
            _applicationContext.Tickets.Add(ticket);
        }
        public void DeleteTicket(int id)
        {
            _applicationContext.Tickets.Remove(_applicationContext.Tickets.Find(id));
        }
        public IEnumerable<Ticket> GetTickets()
        {
            return _applicationContext.Tickets;
        }
        public Ticket GetTicket(int id)
        {
            return _applicationContext.Tickets.Find(id);
        }
        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }
        public void UpdateTicket(Ticket ticket)
        {
            _applicationContext.Tickets.Update(ticket);
        }
    }
}
