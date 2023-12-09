namespace TicketSystem.DTOs
{
    public class PaginatedTicket
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<TicketDto> Tickets { get; set; } 
    }
}
