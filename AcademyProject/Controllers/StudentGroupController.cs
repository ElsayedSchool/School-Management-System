using Application.StudentGroupApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupController : BaseController
    {
        // GET: api/<StudentGroupsController>
        [HttpPost("all")]
        public async Task<ActionResult> GetAllStudentGroups(GetAllStudentGroupsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        // POST api/<StudentGroupsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertStudentGroupCommand newStudent)
        {
            return Ok(await Mediator.Send(newStudent));
        }

        // DELETE api/<StudentGroupsController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteStudentGroupCommand deleteStudentGroup)
        {
            return Ok(await Mediator.Send(deleteStudentGroup));
        }
    }
}
