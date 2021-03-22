using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        #region Constructor Method
        IRentalService _rentalManager;
        IPaymentService _paymentManager;
        IFakeCardService _fakeCardManager;

        public PaymentsController(IRentalService rentalManager, IPaymentService paymentService, IFakeCardService cardService)
        {
            _rentalManager = rentalManager;
            _paymentManager = paymentService;
            _fakeCardManager = cardService;
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

        [HttpPost]
        [Route("add")]
        public IActionResult Add(FakeCreditCard card,Payment pay, Rental rent)
        {
            var cardResult = _fakeCardManager.GetCardByCardNumber(card.CardNumber);
            if (cardResult.Success)
            {
                var payResult = _paymentManager.Add(pay);
                if (payResult.Success)
                {
                    var result = _rentalManager.Add(rent);
                    if (result.Success) return Ok(result);
                    return BadRequest(result);
                }
                return BadRequest(payResult);
            }
            return BadRequest(cardResult);
        }

        #endregion
    }
}
