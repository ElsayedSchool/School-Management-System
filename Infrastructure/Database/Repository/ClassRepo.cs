using Application.ClassApp;
using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class ClassRepo : Repository<Class>, IClassRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public ClassRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<ClassesListVm>>> GetAllClassesAsync()
        {
            try
            {
                var classes = await _applicationDb.Classes
                    .Include(p => p.Teacher)
                    .ThenInclude(p=>p.Profile)
                    .Include(p => p.Hall)
                    .Include(p => p.Course)
                    .Include(p => p.Group)
                    .Select(p => new ClassesListVm()
                    {
                        Id = p.ClassId,
                        ClassName = p.Course.CourseDesc,
                        EnglishName = p.Course.EnglishDesc,
                        ClassPrice = p.ClassPrice,
                        HallId = p.HallId,
                        HallName = p.Hall.HallName,
                        TeacherId = p.TeacherId,
                        TeacherName = p.Teacher.Profile.FullName,
                        GroupId = p.GroupId,
                        GroupName = p.Group.GroupName,
                        CourseId = p.CourseId,
                    })
                    .ToListAsync();
                return new RespDto<List<ClassesListVm>>() { Data = classes };
            }
            catch (Exception ex)
            {
                return new RespDto<List<ClassesListVm>>().Get500Error(ex.Message);
            }
        }
    }
}
