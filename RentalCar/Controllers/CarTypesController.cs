using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Repositories;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private IMapper _mapper;
        private CarTypeRepository _carTypeRepository;

        public CarTypesController(IMapper mapper, CarTypeRepository carTypeRepository)
        {
            this._mapper = mapper;
            _carTypeRepository = carTypeRepository;
        }

        // GET: api/CarTypes
        [HttpGet]
        public async Task<IActionResult> GetCarTypes()
        {
            var carTypes = await _carTypeRepository.GetAllCarTypesAsync();

            return Ok(_mapper.Map<ICollection<CarTypeDTO>>(carTypes));
        }
    }
}
