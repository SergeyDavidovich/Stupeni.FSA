using AutoMapper;
using Stupeni.FSA.Booking.Dto;

namespace Stupeni.FSA;

public class FSAApplicationAutoMapperProfile : Profile
{
    public FSAApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Entities.Booking, BookingDto>();
    }
}
