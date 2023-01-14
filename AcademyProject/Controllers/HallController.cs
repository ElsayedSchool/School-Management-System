using Application.HallApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : BaseController
    {
        // GET: api/<HallController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllHalls()
        {
            return Ok(await Mediator.Send(new GetAllHallsQuery()));
        }

        // GET api/<HallController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetHallDetail(GetHallDetailQuery hall)
        {
            return Ok(await Mediator.Send(hall));
        }

        // POST api/<HallController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertHallCommand hall)
        {
            return Ok(await Mediator.Send(hall));
        }

        // DELETE api/<HallController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteHallCommand deleteHall)
        {
            return Ok(await Mediator.Send(deleteHall));
        }
    }
}
