using AutoMapper;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarWashBooking, BookingResponseDTO>();
            CreateMap<CreateBookingDTO, CarWashBooking>();
            CreateMap<UpdateBookingDTO, CarWashBooking>();
        }
    }
}
