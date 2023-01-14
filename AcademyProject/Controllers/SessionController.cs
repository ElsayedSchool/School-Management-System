using Application.SessionApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : BaseController
    {
        // GET: api/<SessionController>
        [HttpPost("all")]
        public async Task<ActionResult> GetAllSession(GetAllSessionsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        // POST api/<SessionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertSessionCommand newStudent)
        {
            return Ok(await Mediator.Send(newStudent));
        }

        // DELETE api/<SessionController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteSessionCommand deleteSession)
        {
            return Ok(await Mediator.Send(deleteSession));
        }
    }
}
