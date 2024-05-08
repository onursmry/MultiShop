using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var result = _cargoCustomerService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoCustomer([FromBody] CreateCargoCustomerDto cargoCustomer)
        {
            _cargoCustomerService.TAdd(new CargoCustomer
            {
                Name = cargoCustomer.Name,
                Surname = cargoCustomer.Surname,
                Email = cargoCustomer.Email,
                Phone = cargoCustomer.Phone,
                District = cargoCustomer.District,
                City = cargoCustomer.City,
                Address = cargoCustomer.Address
            });
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer([FromBody] UpdateCargoCustomerDto cargoCustomer)
        {
            _cargoCustomerService.TUpdate(new CargoCustomer
            {
                CargoCustomerId = cargoCustomer.CargoCustomerId,
                Name = cargoCustomer.Name,
                Surname = cargoCustomer.Surname,
                Email = cargoCustomer.Email,
                Phone = cargoCustomer.Phone,
                District = cargoCustomer.District,
                City = cargoCustomer.City,
                Address = cargoCustomer.Address
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok();
        }
    }
}
