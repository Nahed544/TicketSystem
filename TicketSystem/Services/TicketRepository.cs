using Microsoft.EntityFrameworkCore;
using TicketSystem.Interfaces;
using TicketSystem.Models;

namespace TicketSystem.Services
{
    public class TicketRepository : ITicketRepository
    {
        private ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            ticket.CreationDateTime = DateTime.Now;
            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            return ticket;
        }

        public async Task<Tuple<List<Ticket>, int>> GetTickets(int page = 1, int pageSize = 5)
        {
            var ticketsCount = _dbContext.Tickets.Count();
            var tickets = await _dbContext.Tickets.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = new Tuple<List<Ticket>, int>(tickets, ticketsCount);
            return result;

        }
         
        async Task<Ticket> ITicketRepository.Update(Ticket ticket)
        {
            _dbContext.Entry(ticket).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return ticket;
        }


    }
}
