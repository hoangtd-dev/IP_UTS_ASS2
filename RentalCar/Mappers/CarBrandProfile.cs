using AutoMapper;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Enums;

namespace RentalCar.Mappers
{
    public class CarBrandProfile : Profile
    {
        public CarBrandProfile()
        {
            CreateMap<CarBrand, CarBrandDTO>();
            CreateMap<CarBrand, SearchSuggestionDTO>()
                .ForMember(dest => dest.Suggestion, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.SuggestionType, opt => opt.MapFrom(_ => SuggestionType.CarBrand));
        }
    }
}
