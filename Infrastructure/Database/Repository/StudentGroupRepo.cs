using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Application.StudentGroupApp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class StudentGroupRepo : Repository<StudentGroup>, IStudentGroupRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public StudentGroupRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<StudentGroupsListVm>>> GetAllGroupStudents(int groupId)
        {
            try
            {
                var groupStudentsList = await _applicationDb.StudentGroup
                    .Where(x => x.GroupId == groupId)
                    .Include(p => p.Group)
                    .Include(p => p.Student)
                    .Select(p => new StudentGroupsListVm()
                    {
                        Id = p.StudentGroupId,
                        StudentId = p.StudentId,
                        StudentName = p.Student.FullName,
                        StudentPhone = p.Student.Phone,
                        GroupId = p.GroupId,
                        GroupName = p.Group.GroupName,
                        JoinDate = p.JoinDate
                    })
                    .ToListAsync();

                return new RespDto<List<StudentGroupsListVm>>() { Data = groupStudentsList };
            }
            catch (Exception ex)
            {
                return new RespDto<List<StudentGroupsListVm>>().Get500Error(ex.Message);
            }
        }
    }
}
