using Application.BranchApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : BaseController
    {


        // GET: api/<BranchController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllBranches()
        {
            return Ok(await Mediator.Send(new GetAllBranchesQuery()));
        }

        // GET api/<BranchController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetBranchDetail(GetBranchDetailQuery branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // POST api/<BranchController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpsertBranchCommand branch)
        {
            return Ok(await Mediator.Send(branch));
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteBranchCommand deleteBranch)
        {
            return Ok(await Mediator.Send(deleteBranch));
        }
    }
}
