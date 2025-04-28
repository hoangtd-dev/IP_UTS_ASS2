using AutoMapper;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Enums;

namespace RentalCar.Mappers
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<Car, SearchSuggestionDTO>()
                .ForMember(dest => dest.Suggestion, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.SuggestionType, opt => opt.MapFrom(_ => SuggestionType.CarName));
        }
    }
}
