using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        #region Constructor Method
        IColorService _colorManager;

        public ColorsController(IColorService colorManager)
        {
            _colorManager = colorManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _colorManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _colorManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorManager.Delete(color);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorManager.Update(color);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorManager.Add(color);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
