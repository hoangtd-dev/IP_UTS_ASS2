namespace RentalCar.DTOs
{
    public class CreateReservationModel
    {
        public string CarId { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DriverLicense { get; set; }
        public DateTime StartDate { get; set; }
        public int RentalPeriod { get; set; }
    }
}
