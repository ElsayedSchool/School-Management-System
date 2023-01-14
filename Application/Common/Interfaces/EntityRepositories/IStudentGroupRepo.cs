using Application.Common.Models;
using Application.StudentGroupApp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public interface IStudentGroupRepo: IRepository<StudentGroup>
    {
        Task<RespDto<List<StudentGroupsListVm>>> GetAllGroupStudents(int groupId);
    }
}
