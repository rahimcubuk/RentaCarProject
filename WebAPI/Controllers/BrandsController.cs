using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract.Services;
using Project.Entities.Concrete.Models;

namespace WebAPI.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        #region Constructor Method
        IBrandService _brandManager;

        public BrandsController(IBrandService brandManager)
        {
            _brandManager = brandManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _brandManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _brandManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandManager.Delete(brand);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandManager.Update(brand);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandManager.Add(brand);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
