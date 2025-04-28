
namespace RentalCar.Entities.DefaultData
{
    public class VINGenerator
    {
        public static string GenerateVIN()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 17).ToUpper();
        }
    }
}
