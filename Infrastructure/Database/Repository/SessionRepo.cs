using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Application.TeacherApp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class SessionRepo : Repository<Session>, ISessionRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public SessionRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

       /* public async Task<RespDto<List<SessionsListVm>>> GetAllTeachers()
        {
            try
            {
                var teachers = await _applicationDb.Teachers
                    .Include(p => p.Profile)
                    .ThenInclude(p => p.Manager)
                    .Include(p=>p.Course)
                    .Select(p => new TeachersListVm()
                    {
                        Id = p.TeacherId,
                        TeacherName = p.Profile.FullName,
                        Phone = p.Profile.Phone,
                        JobTtitle = p.Profile.JobTitle,
                        YearsOfExperience = p.YearsOfExperience,
                        CourseId = p.Course.CourseId,
                        Course = p.Course.CourseName,
                        ManagerId = p.Profile.Manager != null ? p.Profile.Manager.UserProfileId : null ,
                        ManagerName = p.Profile.Manager != null ? p.Profile.Manager.FullName : "",
                    }).ToListAsync();
                return new RespDto<List<TeachersListVm>>() { Data = teachers };
            }
            catch (Exception ex)
            {
                return new RespDto<List<TeachersListVm>>().Get500Error(ex.Message);
            }
        }*/
    }
}
