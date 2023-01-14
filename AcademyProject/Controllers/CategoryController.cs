using Application.CategoryApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {


        // GET: api/<CategoryController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllCategoryes()
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertCategoryCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteCategoryCommand deleteCategory)
        {
            return Ok(await Mediator.Send(deleteCategory));
        }
    }
}
