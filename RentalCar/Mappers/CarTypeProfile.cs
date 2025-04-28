using AutoMapper;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Enums;

namespace RentalCar.Mappers
{
    public class CarTypeProfile : Profile
    {
        public CarTypeProfile()
        {
            CreateMap<CarType, CarTypeDTO>();
            CreateMap<CarType, SearchSuggestionDTO>()
                .ForMember(dest => dest.Suggestion, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.SuggestionType, opt => opt.MapFrom(_ => SuggestionType.CarType));
        }
    }
}
