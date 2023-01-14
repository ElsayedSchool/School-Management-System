using Application.Common.Models;
using Application.EmployeeApp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public interface IEmployeeRepo: IRepository<Employee>
    {
        Task<RespDto<List<EmployeesListVm>>> GetAllEmployees();
    }
}
