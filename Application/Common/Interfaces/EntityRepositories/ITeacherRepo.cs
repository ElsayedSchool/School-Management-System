using Application.Common.Models;
using Application.TeacherApp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public interface ITeacherRepo: IRepository<Teacher>
    {
        Task<RespDto<List<TeachersListVm>>> GetAllTeachers();
    }
}
