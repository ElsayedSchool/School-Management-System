using Application.StudentParentApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentParentsController : BaseController
    {
        // GET: api/<StudentParentsController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllStudentParents()
        {
            return Ok(await Mediator.Send(new GetAllStudentParentsQuery()));
        }


        // POST api/<StudentParentParentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertStudentParentCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<StudentParentParentsController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteStudentParentCommand deleteStudentParent)
        {
            return Ok(await Mediator.Send(deleteStudentParent));
        }
    }
}
