using Application.CategoryCourseApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatCourseController : BaseController
    {


        // GET: api/<CatCourseController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllCatCoursees()
        {
            return Ok(await Mediator.Send(new GetAllCatCoursesQuery()));
        }

        // POST api/<CatCourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertCategoryCourseCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<CatCourseController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteCategoryCourseCommand deleteCatCourse)
        {
            return Ok(await Mediator.Send(deleteCatCourse));
        }
    }
}
