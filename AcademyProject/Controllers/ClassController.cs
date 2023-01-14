using Application.ClassApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : BaseController
    {

        // GET: api/<ClassController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllClasses()
        {
            return Ok(await Mediator.Send(new GetAllClassesQuery()));
        }

        // GET api/<ClassController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetClassDetail(GetClassDetailQuery groupClass)
        {
            return Ok(await Mediator.Send(groupClass));
        }

        // POST api/<ClassController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertClassCommand groupClass)
        {
            return Ok(await Mediator.Send(groupClass));
        }

        // DELETE api/<ClassController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteClassCommand deleteClass)
        {
            return Ok(await Mediator.Send(deleteClass));
        }
    }
}
