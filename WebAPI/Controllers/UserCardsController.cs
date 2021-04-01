using Business.Abstract.Services;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/usercard")]
    [ApiController]
    public class UserCardsController : ControllerBase
    {
        #region Constructor Method
        IUserCardService _userCardManager;

        public UserCardsController(IUserCardService userCardService)
        {
            _userCardManager = userCardService;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _userCardManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _userCardManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("detail/list")]
        public IActionResult GetDetailByUser(int user)
        {
            var result = _userCardManager.GetUserCardByUserId(user);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("detail/list/{id}")]
        public IActionResult GetDetailById(int id)
        {
            var result = _userCardManager.GetUserCardById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(UserCard card)
        {
            var result = _userCardManager.Delete(card);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(UserCard card)
        {
            var result = _userCardManager.Update(card);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(UserCard card)
        {
            var result = _userCardManager.Add(card);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
