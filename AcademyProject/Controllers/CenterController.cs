using Application.CenterApp;
using Application.CenterApp.Query.GetCenter;
using Application.CenterApp.Query.GetSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : BaseController
    {
        // GET: api/<CenterController>
        [HttpGet("center")]
        public async Task<ActionResult> GetCenterAsync()
        {
            return Ok(await Mediator.Send(new GetCenterQuery()));
        }

        [HttpGet("setting")]
        public async Task<ActionResult> GetSettingAsync()
        {
            return Ok(await Mediator.Send(new GetSettingQuery()));
        }

        // POST api/<CenterController>
        [HttpPost("center")]
        public async Task<ActionResult> UpdateCenterAsync([FromBody] UpdateCenterCommand value)
        {
            return Ok(await Mediator.Send(value));
        }


        [HttpPost("setting")]
        public async Task<ActionResult> UpdateSettingAsync([FromBody] UpdateSettingCommand value)
        {
            return Ok(await Mediator.Send(value));
        }

    }
}
