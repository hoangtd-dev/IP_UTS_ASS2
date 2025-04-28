using Microsoft.EntityFrameworkCore;
using RentalCar.Entities;
using RentalCar.Infrastructure;

namespace RentalCar.Repositories
{
    public class CarTypeRepository
    {
        private readonly AppDbContext _context;
        public CarTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarType>> GetAllCarTypesAsync()
        {
            return await _context.CarTypes.ToListAsync();
        }
    }
}
