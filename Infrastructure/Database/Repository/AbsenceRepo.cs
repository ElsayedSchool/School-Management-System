using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Application.StudentAbsenceApp;
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
    public class AbsenceRepo : Repository<StudentAbsence>, IAbsenceRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public AbsenceRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<StudentAbsencesListVm>>> GetAllAbsenceList()
        {
            try
            {
                var absence = await _applicationDb.StudentAbsence
                    .Include(p => p.Student)
                    .Include(p => p.Session)
                    .Select(p => new StudentAbsencesListVm()
                    {
                        SessionId = p.SessionId,
                        StudentId = p.StudentId,
                        StudentName = p.Student.FullName,
                        StudentPhone = p.Student.Phone,
                        IsSick = p.IsSick,
                        AbsenceDate = p.Session.StartDate.Date,
                        SessionName = p.Session.Title
                    }).ToListAsync();
                return new RespDto<List<StudentAbsencesListVm>>() { Data = absence };
            }
            catch (Exception ex)
            {
                return new RespDto<List<StudentAbsencesListVm>>().Get500Error(ex.Message);
            }
        }
    }
}
