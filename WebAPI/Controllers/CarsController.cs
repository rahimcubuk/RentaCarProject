using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract.Services;
using Project.Entities.Concrete.Models;

namespace WebAPI.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        #region Constructor Method
        ICarService _carManager;

        public CarsController(ICarService carManager)
        {
            _carManager = carManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _carManager.GetCarsDetails();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
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
            var result = _carManager.GetCarsByColorId(colorid);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("listbybrand/{brandid}")]
        public IActionResult GetByBrand(int brandid)
        {
            var result = _carManager.GetCarsByBrandId(brandid);

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
