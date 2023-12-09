using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DTOs;
using TicketSystem.Interfaces;
using TicketSystem.Models;
using TicketSystem.ViewModels;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _repository = ticketRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketAsync([FromBody] TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            } 
            var ticket = _mapper.Map<Ticket>(ticketViewModel);
            await _repository.CreateAsync(ticket);
            return Ok(ticket);

        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetTickets(int pageNumber = 1, int pageSize = 5)
        {
            var ticketsWithCount = await _repository.GetTickets(pageNumber, pageSize);
            var ticketsDto = _mapper.Map<List<TicketDto>>(ticketsWithCount?.Item1);
            var paginatedTicket = new PaginatedTicket
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Tickets = ticketsDto,
                TotalItems = ticketsWithCount.Item2
            };

            return Ok(paginatedTicket);
        }

        [HttpPost("{id}/handle")]
        public async Task<IActionResult> HandleTicketAsync(int id)
        {
            var ticket = await _repository.GetTicketById(id);
            if (ticket == null)
            { return NotFound(); }

            ticket.IsHandled = true;
            {
                await _repository.Update(ticket);
            }
            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return Ok(ticketDto);
        }
    }
}
