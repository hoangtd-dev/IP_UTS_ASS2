using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Enums;
using RentalCar.Infrastructure;

namespace RentalCar.Repositories
{
    public class CarRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<ICollection<SearchSuggestionDTO>> GetSearchSuggestions(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return Array.Empty<SearchSuggestionDTO>();

            var carBrandSuggestions = await _context.CarBrands
                .Where(x => x.Name!.Contains(searchTerm))
                .Take(5)
                .ToListAsync();

            var carBrandSuggestionsMapping = _mapper
                .Map<ICollection<SearchSuggestionDTO>>(carBrandSuggestions);

            var carTypeSuggestions = await _context.CarTypes
                .Where(x => x.Name!.Contains(searchTerm))
                .Take(5)
                .ToListAsync();

            var carTypeSuggestionsMapping = _mapper
                .Map<ICollection<SearchSuggestionDTO>>(carTypeSuggestions);

            var carNameSuggestions = await _context.Cars
                .Where(x => x.Name!.Contains(searchTerm))
                .Take(5)
                .ToListAsync();

            var carNameSuggestionsMapping = _mapper
                .Map<ICollection<SearchSuggestionDTO>>(carNameSuggestions);

            var searchSuggestions = new List<SearchSuggestionDTO>();
            searchSuggestions.AddRange(carBrandSuggestionsMapping);
            searchSuggestions.AddRange(carTypeSuggestionsMapping);
            searchSuggestions.AddRange(carNameSuggestionsMapping);

            return searchSuggestions;
        }

        public async Task<ICollection<Car>> Search(ICollection<QuerySearchSuggestion>? searchSuggestions)
        {
            var carTypes = searchSuggestions?.Where(x => x.SuggestionType == SuggestionType.CarType).Select(x => x.CarTypeId).AsQueryable();
            var carBrands = searchSuggestions?.Where(x => x.SuggestionType == SuggestionType.CarBrand).Select(x => x.CarBrandId).AsQueryable();
            var carNames = searchSuggestions?.LastOrDefault(x => x.SuggestionType == SuggestionType.CarName);

            var query = _context.Cars.AsQueryable();

            if (carTypes != null && carTypes.Any())
            {
                query = query.Where(x => carTypes.Contains(x.CarTypeId));
            }

            if (carBrands != null && carBrands.Any())
            {
                query = query.Where(x => carBrands.Contains(x.CarBrandId));
            }

            if (carNames != null && !string.IsNullOrEmpty(carNames.SearchTerm))
            {
                var searchTerm = carNames.SearchTerm.Trim();
                query = query.Where(x => x.Name!.Contains(searchTerm) 
                    || x.CarBrand!.Name!.Contains(searchTerm)
                    || x.CarType!.Name!.Contains(searchTerm)
                    || x.Description!.Contains(searchTerm)
                    || x.CarModel!.Contains(searchTerm)
                );
            }

            return await query
                .Include(x => x.CarBrand)
                .Include(x => x.CarType)
                .ToListAsync();
        }
    }
}
