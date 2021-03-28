using Business.Abstract.Services;
using Business.Constants;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private IFakeCardService _cardService;
        public CardsController(IFakeCardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [Route("check/{price}")]
        public IActionResult Get(FakeCreditCard card, decimal price)
        {
            var cardResult = _cardService.CheckCard(card, price);

            if (cardResult.Success)
            {
                return Ok(cardResult);
            }
            return BadRequest(cardResult);
        }
    }
}
