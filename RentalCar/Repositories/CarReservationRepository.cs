using RentalCar.DTOs;
using RentalCar.Entities;
using RentalCar.Infrastructure;

namespace RentalCar.Repositories
{
    public class CarReservationRepository
    {
        private readonly AppDbContext _context;
        public CarReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task RentCar(CreateReservationModel model)
        {
            var car = await _context.Cars.FindAsync(model.CarId);

            if (car == null)
            {
                throw new Exception("Car not found");
            }

            if (!car.IsAvailable) 
            {
                throw new Exception("Car is not available for rent");
            }

            car.IsAvailable = false;

            var newReservation = new CarReservation
            {
                CarId = model.CarId,
                Phone = model.Phone,
                Username = model.Username,
                Email = model.Email,
                DriverLicense = model.DriverLicense,
                StartDate = model.StartDate,
                RentalPeriod = model.RentalPeriod
            };

            _context.CarReservations.Add(newReservation);
            await _context.SaveChangesAsync();
        }
    }
}
