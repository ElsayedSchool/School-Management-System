using Application.StudentApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        // GET: api/<StudentController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllStudents()
        {
            return Ok(await Mediator.Send(new GetAllStudentsQuery()));
        }

        [HttpPost("Detail")]
        public async Task<ActionResult> GetStudentDetail()
        {
            return Ok(await Mediator.Send(new GetAllStudentsQuery()));
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertStudentCommand student)
        {
            return Ok(await Mediator.Send(student));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteStudentCommand deleteStudent)
        {
            return Ok(await Mediator.Send(deleteStudent));
        }
    }
}
