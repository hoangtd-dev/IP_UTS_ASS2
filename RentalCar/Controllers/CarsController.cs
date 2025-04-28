using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Repositories;
using System.Text.Json;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IMapper _mapper;
        private CarRepository _carRepository;
        public CarsController(IMapper mapper, CarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ICollection<CarDTO>> GetCars([FromQuery] string? searchSuggestions)
        {
           var searchSuggestionsList = new List<QuerySearchSuggestion>();
            if (!string.IsNullOrEmpty(searchSuggestions))
            {
                searchSuggestionsList = JsonSerializer.Deserialize<List<QuerySearchSuggestion>>(searchSuggestions);
            }
            var cars = await _carRepository.Search(searchSuggestionsList);
            return _mapper.Map<ICollection<CarDTO>>(cars);
        }

        [HttpGet("search-suggestions")]
        public async Task<ICollection<SearchSuggestionDTO>> GetSearchSuggestions([FromQuery] string searchTerm)
        {
            var searchSuggestions = await _carRepository.GetSearchSuggestions(searchTerm);
            return searchSuggestions;
        }
    }
}
