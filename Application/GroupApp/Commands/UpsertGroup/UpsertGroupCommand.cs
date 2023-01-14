using Application.Common.Mediatr;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    
    
    public class UpsertGroupCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int StudentPayment { get; set; }
        public int BranchId { get; set; }
        public int GradeId { get; set; }
    }
}
