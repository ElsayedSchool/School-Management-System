using Application.EmployeeApp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
       
        // GET: api/<EmployeeController>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllEmployees()
        {
            return Ok(await Mediator.Send(new GetAllEmployeesQuery()));
        }

        // GET api/<EmployeeController>/5
        [HttpPost("Detail")]
        public async Task<ActionResult> GetEmployeeDetail(GetEmployeeDetailQuery employee)
        {
            return Ok(await Mediator.Send(employee));
        }

        // POST api/<EmployeeController>
        [HttpPost("employee")]
        public async Task<ActionResult> UpsertEmployeeData([FromBody] UpsertEmployeeCommand employee)
        {
            return Ok(await Mediator.Send(employee));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("remove")]
        public async Task<ActionResult> Delete(DeleteEmployeeCommand deleteEmployee)
        {
            return Ok(await Mediator.Send(deleteEmployee));
        }
    }
}
