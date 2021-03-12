using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        #region Constructor Method
        IRentalService _rentalManager;

        public RentalController(IRentalService rentalManager)
        {
            _rentalManager = rentalManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _rentalManager.GetRentalDetails();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _rentalManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Rental rent)
        {
            var result = _rentalManager.Delete(rent);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Rental rent)
        {
            var result = _rentalManager.Update(rent);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Rental rent)
        {
            var result = _rentalManager.Add(rent);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion

    }
}
