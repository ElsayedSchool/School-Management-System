using Application.ClassApp;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public  interface IClassRepo: IRepository<Class>
    {
        Task<RespDto<List<ClassesListVm>>> GetAllClassesAsync();
    }
}
