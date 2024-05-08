using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var result = _cargoCompanyService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoCompany([FromBody] CreateCargoCompanyDto cargoCompany)
        {
            _cargoCompanyService.TAdd(new CargoCompany
            {
                CargoCompanyName = cargoCompany.CargoCompanyName
            });
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var result = _cargoCompanyService.TGetById(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany([FromBody] UpdateCargoCompanyDto cargoCompany)
        {
            _cargoCompanyService.TUpdate(new CargoCompany
            {
                CargoCompanyId = cargoCompany.CargoCompanyId,
                CargoCompanyName = cargoCompany.CargoCompanyName
            });
            return Ok();
        }
    }
}
