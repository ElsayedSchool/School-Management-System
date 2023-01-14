using Application.TeacherApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : BaseController
    {

        // GET: api/<CourseController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllTeachers()
        {
            return Ok(await Mediator.Send(new GetAllTeachersQuery()));
        }

        [HttpPost("Detail")]
        public async Task<ActionResult> GetTeacherDetail()
        {
            return Ok(await Mediator.Send(new GetAllTeachersQuery()));
        }

        // POST api/<TeacherController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertTeacherCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteTeacherCommand deleteTeacher)
        {
            return Ok(await Mediator.Send(deleteTeacher));
        }
    }
}
