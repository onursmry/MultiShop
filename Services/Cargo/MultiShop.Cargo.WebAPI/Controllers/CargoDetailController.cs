using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoDetail([FromBody] CreateCargoDetailDto cargoDetail)
        {
            _cargoDetailService.TAdd(new CargoDetail
            {
                Barcode = cargoDetail.Barcode,
                CargoCompanyId = cargoDetail.CargoCompanyId,
                CargoReceiver = cargoDetail.CargoReceiver,
                CargoSender = cargoDetail.CargoSender
            });
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail([FromBody] UpdateCargoDetailDto cargoDetail)
        {
            _cargoDetailService.TUpdate(new CargoDetail
            {
                CargoDetailId = cargoDetail.CargoDetailId,
                Barcode = cargoDetail.Barcode,
                CargoCompanyId = cargoDetail.CargoCompanyId,
                CargoReceiver = cargoDetail.CargoReceiver,
                CargoSender = cargoDetail.CargoSender
            });
            return Ok();
        }
    }
}
