using Business.Abstract.Services;
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

        [HttpGet]
        [Route("check/{card}")]
        public IActionResult Get(string card)
        {
            var result = _cardService.GetCardByCardNumber(card);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
