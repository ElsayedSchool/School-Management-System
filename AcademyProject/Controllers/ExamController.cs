using Application.ExamApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : BaseController
    {
        // GET: api/<ExamController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllExams()
        {
            return Ok(await Mediator.Send(new GetAllExamsQuery()));
        }

        [HttpPost("Detail")]
        public async Task<ActionResult> GetExamDetail()
        {
            return Ok(await Mediator.Send(new GetAllExamsQuery()));
        }

        // POST api/<ExamController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertExamCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteExamCommand deleteExam)
        {
            return Ok(await Mediator.Send(deleteExam));
        }
    }
}
