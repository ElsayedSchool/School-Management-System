using Application.ExamResultApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : BaseController
    {
        // GET: api/<ExamResultController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllExamResults()
        {
            return Ok(await Mediator.Send(new GetAllExamResultsQuery()));
        }

        [HttpPost("Detail")]
        public async Task<ActionResult> GetExamResultDetail()
        {
            return Ok(await Mediator.Send(new GetAllExamResultsQuery()));
        }

        // POST api/<ExamResultController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertExamResultCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<ExamResultController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteExamResultCommand deleteExamResult)
        {
            return Ok(await Mediator.Send(deleteExamResult));
        }
    }
}
