using Application.ParentApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : BaseController
    {
        // GET: api/<ParentController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllParents()
        {
            return Ok(await Mediator.Send(new GetAllParentsQuery()));
        }

        [HttpPost("Detail")]
        public async Task<ActionResult> GetParentDetail()
        {
            return Ok(await Mediator.Send(new GetAllParentsQuery()));
        }

        // POST api/<ParentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertParentCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<ParentController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteParentCommand deleteParent)
        {
            return Ok(await Mediator.Send(deleteParent));
        }
    }
}
