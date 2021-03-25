using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        #region Constructor Method
        IPaymentService _paymentManager;

        public PaymentsController(IPaymentService paymentManager)
        {
            _paymentManager = paymentManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _paymentManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        #endregion
    }
}
