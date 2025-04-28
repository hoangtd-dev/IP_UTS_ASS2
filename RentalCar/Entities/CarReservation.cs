namespace RentalCar.Entities
{
    public class CarReservation
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public virtual Car Car { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DriverLicense { get; set; }
        public DateTime StartDate { get; set; }
        public int RentalPeriod { get; set; }
    }
}
