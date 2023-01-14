using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentGroupApp
{
    public class GetAllStudentGroupsQuery : IRequestWrapper<List<StudentGroupsListVm>>
    {
        public int GroupId { get; set; }
    }
}
