using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Constructor Method
        ICustomerService _customerManager;

        public CustomersController(ICustomerService customerManager)
        {
            _customerManager = customerManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _customerManager.GetCustomersDetails();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _customerManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerManager.Delete(customer);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerManager.Update(customer);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerManager.Add(customer);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
