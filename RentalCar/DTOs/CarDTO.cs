using RentalCar.Entities;

namespace RentalCar.DTOs
{
    public class CarDTO
    {
        public string VIN { get; set; }
        public string? Name { get; set; }
        public int CarBrandId { get; set; }
        public CarBrandDTO CarBrand { get; set; }
        public int CarTypeId { get; set; }
        public CarTypeDTO CarType { get; set; }
        public string CarModel { get; set; }
        public string? ImageUrl { get; set; }
        public decimal PricePerDay { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal Mileage { get; set; }
        public string? FuelType { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
