using Microsoft.EntityFrameworkCore;
using RentalCar.Entities;
using RentalCar.Infrastructure;

namespace RentalCar.Repositories
{
    public class CarBrandRepository
    {
        private readonly AppDbContext _context;
        public CarBrandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync()
        {
            return await _context.CarBrands.ToListAsync();
        }
    }
}
