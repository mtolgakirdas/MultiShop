using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperaitonList()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateCargoOperaiton(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
               Barcode = createCargoOperationDto.Barcode,
               Description = createCargoOperationDto.Description,
               OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(CargoOperation);
            return Ok("Kargo Detayları başarıyla oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperaiton(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Detayları başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperaitonById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperaiton(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description= updateCargoOperationDto.Description,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _cargoOperationService.TUpdate(CargoOperation);
            return Ok("Kargo Detayları başarıyla güncellendi.");
        }
    }
}
