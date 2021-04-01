using Business.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/findexpoint")]
    [ApiController]
    public class FindexPointsController : ControllerBase
    {
        private IFindexPointService _findexPointService;
        public FindexPointsController(IFindexPointService findexPointService)
        {
            _findexPointService = findexPointService;
        }

        [HttpGet]
        [Route("check/{card}")]
        public IActionResult CheckPoint(int card)
        {
            var data = _findexPointService.GetById(card);

            if (data.Success) return Ok(data);
            return BadRequest(data);
        }

    }
}
