using AutoMapper;
using TicketSystem.DTOs;
using TicketSystem.Models;
using TicketSystem.ViewModels;

namespace TicketSystem
{
    public class AutoMapperConfigration : Profile
    {
        public AutoMapperConfigration()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<Ticket, TicketViewModel>().ReverseMap();
        }
    }
}
