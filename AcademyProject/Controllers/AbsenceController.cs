using Application.StudentAbsenceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : BaseController
    {
        // GET: api/<AbsenceController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllAbsencees()
        {
            return Ok(await Mediator.Send(new GetAllStudentAbsencesQuery()));
        }

        /*// GET api/<StudentAbsenceController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetStudentAbsenceDetail(GetStudentAbsenceDetailQuery StudentAbsence)
        {
            return Ok(await Mediator.Send(StudentAbsence));
        }*/

        // POST api/<StudentAbsenceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertStudentAbsenceCommand StudentAbsence)
        {
            return Ok(await Mediator.Send(StudentAbsence));
        }

        // DELETE api/<StudentAbsenceController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteStudentAbsenceCommand deleteStudentAbsence)
        {
            return Ok(await Mediator.Send(deleteStudentAbsence));
        }
    }
}
