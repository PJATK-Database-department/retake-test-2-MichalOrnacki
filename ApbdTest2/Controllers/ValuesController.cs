using ApbdTest2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApbdTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ValuesController(IDbService dbService)
        {
            _dbService = dbService;
        }
        // GET: api/<ValuesController>
        [HttpGet("ConnectionTest")]
        public async Task<IActionResult> Get()
        {
            var a = await _dbService.GetFirefighter();
            return Ok(a);
        }
        [HttpGet("{IdFiretruck}")]
        public async Task<IActionResult> GetFiretruckDetails([FromRoute] int IdFiretruck)
        {
            if (!await _dbService.DoesFiretruckExist(IdFiretruck))
            {
                return BadRequest($"Firetruck with id {IdFiretruck} does not exist");
            }

            var a = await _dbService.GetFiretruckDetails(IdFiretruck);
            return Ok(a);
        }

        [HttpPut("{IdAction}")]
        public async Task<IActionResult> UpdateTaskEndDate([FromRoute] int IdAction, [FromBody] DateTime date)
        {
            if()

            await _dbService.UpdateEndTime(IdAction, date);
            return NoContent();
        }

    }
}
