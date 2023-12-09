using TicketSystem.Models;

namespace TicketSystem.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<Ticket> Update(Ticket ticket);
        Task<Ticket> GetTicketById(int id);
        Task<Tuple<List<Ticket>, int>> GetTickets(int page = 1, int pageSize = 5);
     }
}
