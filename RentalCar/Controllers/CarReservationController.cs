using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Repositories;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReservationController : ControllerBase
    {
        private CarReservationRepository _carReservationRepository;
        public CarReservationController(CarReservationRepository carReservationRepository)
        {
            _carReservationRepository = carReservationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RentCar([FromBody] CreateReservationModel model)
        {
            try
            {
                await _carReservationRepository.RentCar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
