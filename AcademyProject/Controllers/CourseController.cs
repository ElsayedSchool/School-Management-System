using Application.CourseApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
      


        // GET: api/<CourseController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllCoursees()
        {
            return Ok(await Mediator.Send(new GetAllCoursesQuery()));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertCourseCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteCourseCommand deleteCourse)
        {
            return Ok(await Mediator.Send(deleteCourse));
        }
    }
}
