using Application.GroupApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : BaseController
    {
        // GET: api/<GroupController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllGroups()
        {
            return Ok(await Mediator.Send(new GetAllGroupsQuery()));
        }

        // GET api/<GroupController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetGroupDetail(GetGroupDetailQuery branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // POST api/<GroupController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertGroupCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteGroupCommand deleteGroup)
        {
            return Ok(await Mediator.Send(deleteGroup));
        }
    }
}
