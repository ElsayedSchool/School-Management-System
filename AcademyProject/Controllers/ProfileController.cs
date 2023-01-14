using Application.ProfileApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        // POST api/<ProfileController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UpdatePersonalCommand updatePersonal)
        {
            return Ok(await Mediator.Send(updatePersonal));
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteProfileCommand deleteProfile)
        {
            return Ok(await Mediator.Send(deleteProfile));
        }
    }
}
