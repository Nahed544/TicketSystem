using Microsoft.EntityFrameworkCore;
using TicketSystem.Interfaces;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
    }
}
