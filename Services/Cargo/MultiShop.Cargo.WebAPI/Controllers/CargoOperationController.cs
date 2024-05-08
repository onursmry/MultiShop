using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoOperation([FromBody] CreateCargoOperationDto cargoOperation)
        {
            _cargoOperationService.TAdd(new CargoOperation
            {
                Barcode = cargoOperation.Barcode,
                Description = cargoOperation.Description,
                OperationDate = cargoOperation.OperationDate
            });
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation([FromBody] UpdateCargoOperationDto cargoOperation)
        {
            _cargoOperationService.TUpdate(new CargoOperation
            {
                CargoOperationId = cargoOperation.CargoOperationId,
                Barcode = cargoOperation.Barcode,
                Description = cargoOperation.Description,
                OperationDate = cargoOperation.OperationDate
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok();
        }
    }
}
