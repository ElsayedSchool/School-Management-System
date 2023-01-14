using Application.Common.Models;
using Application.StudentParentApp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public interface IStudentParentRepo:IRepository<StudentParent>
    {
        Task<RespDto<List<StudentParentsListVm>>> GetAllStudentParents();
    }
}
