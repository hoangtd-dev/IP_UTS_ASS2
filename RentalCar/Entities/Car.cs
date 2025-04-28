namespace RentalCar.Entities
{
    public class Car
    {
        public string? VIN { get; set; }
        public string? Name { get; set; }

        public string? ImageUrl { get; set; }
        public decimal PricePerDay { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal Mileage { get; set; }
        public string? FuelType { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public string? CarModel { get; set; }

        public int CarBrandId { get; set; }
        public virtual CarBrand? CarBrand { get; set; }
        public int CarTypeId { get; set; }
        public virtual CarType? CarType { get; set; }

        public virtual ICollection<CarReservation> CarReservations { get; set; }
    }
}
