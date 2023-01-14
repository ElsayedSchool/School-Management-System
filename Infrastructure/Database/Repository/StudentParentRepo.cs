using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Application.StudentParentApp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class StudentParentRepo : Repository<StudentParent>, IStudentParentRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public StudentParentRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<StudentParentsListVm>>> GetAllStudentParents()
        {
            try
            {
                var studentParents =  await _applicationDb.StudentParents
                .Include(p => p.Parent)
                .Include(p => p.Student)
                .Select(p => new StudentParentsListVm()
                {
                    Id = p.StudentParentId,
                    IsApproved = p.IsApproved,
                    StudentId = p.StudentId,
                    StudentName = p.Student.FullName,
                    StudentPhone = p.Student.Phone,
                    ParentId = p.ParentId,
                    ParentName = p.Parent.FullName,
                    ParentPhone = p.Parent.Phone
                }).ToListAsync();
                return new RespDto<List<StudentParentsListVm>>() { Data = studentParents };
            }
            catch (Exception ex)
            {
                return new RespDto<List<StudentParentsListVm>>().Get500Error(ex.Message);
            }
            
        }
    }
}
