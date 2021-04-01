using Microsoft.AspNetCore.Mvc;
using Business.Abstract.Services;
using Core.Entities.Concrete;
using Entities.Concrete.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Constructor Method
        IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _userManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _userManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userManager.Delete(user);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(UserForUpdateDto data)
        {
            var result = _userManager.UpdateUser(data);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
