using Application.Authentication;
using Application.Authentication;
using Application.Authentication;
using Application.Authentication;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator Mediator;

        public AuthController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpCommand newUser)
        {
            return Ok(await Mediator.Send(newUser));
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInCommand user)
        {
            return Ok(await Mediator.Send(user));
        }

        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            return Ok(await Mediator.Send(new SignOutCommand()));
        }


        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand newUserPassword)
        {
            return Ok(await Mediator.Send(newUserPassword));
        }
    }
}
