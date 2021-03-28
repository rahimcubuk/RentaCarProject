using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        #region Constructor Method
        ICarService _carManager;
        IColorService _colorService;
        IBrandService _brandService;

        public CarsController(ICarService carManager, IBrandService brandService, IColorService colorService)
        {
            _carManager = carManager;
            _colorService = colorService;
            _brandService = brandService;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _carManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("listdetails")]
        public IActionResult GetDetails()
        {
            var result = _carManager.GetCarsDetails();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Get(int id)
        {
            var result = _carManager.GetCarDetailById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet()]
        [Route("listbycolor/{colorid}")]
        public IActionResult GetByColor(int colorid)
        {
            var result = _carManager.GetCarsByColor(_colorService.GetById(colorid).Data.ColorName);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("listbybrand/{brandid}")]
        public IActionResult GetByBrand(int brandid)
        {
            var result = _carManager.GetCarsByBrand(_brandService.GetById(brandid).Data.BrandName);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
