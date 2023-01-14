using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Application.EmployeeApp;
using Domain.Entities;
using Infrastructure.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public EmployeeRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<EmployeesListVm>>> GetAllEmployees()
        {
            try
            {
                var employeesQuery = await _applicationDb.Employees
                .Include(p => p.Profile)
                .ThenInclude(p => p.Manager)
                .Include(p => p.Branch)
                .Select(p => new EmployeesListVm()
                {
                    Id = p.EmployeeId,
                    EmployeeName = p.Profile.FullName,
                    Phone = p.Profile.Phone,
                    WorkEndTime = p.WorkEndTime,
                    WorkStartTime = p.WorkStartTime,
                    HireDate = p.Profile.HireDate,
                    ReleaseDate = p.Profile.ReleaseDate,
                    Salary = p.Salary,
                    AbsenceBalance = p.AbsenceBalance,
                    Status = p.Status,
                    BranchName = p.Branch.BranchName,
                    BranchId = p.Branch.BranchId,
                    ManagerId = p.Profile.ReportsTo,
                    ManagerName = p.Profile.Manager.FullName,
                    Photo = p.Profile.Photo,
                    PhotoPath = p.Profile.PhotoPath,
                    JobTitle = p.Profile.JobTitle,
                })
                .ToListAsync();
                return new RespDto<List<EmployeesListVm>>() { Data = employeesQuery };
            }
            catch (Exception ex)
            {
                return new RespDto<List<EmployeesListVm>> { Error = true, Message = ex.Message };
            }
            
        }
    }
}
