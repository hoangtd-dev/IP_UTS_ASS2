using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalCar.DTOs;
using RentalCar.Repositories;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private IMapper mapper;
        private CarBrandRepository carBrandRepository;

        public CarBrandsController(IMapper mapper, CarBrandRepository carBrandRepository)
        {
            this.mapper = mapper;
            this.carBrandRepository = carBrandRepository;
        }

        // GET: api/CarBrands
        [HttpGet]
        public async Task<IActionResult> GetCarBrands()
        {
            var carBrands = await carBrandRepository.GetAllCarBrandsAsync();
            return Ok(mapper.Map<ICollection<CarBrandDTO>>(carBrands));
        }
    }
}
