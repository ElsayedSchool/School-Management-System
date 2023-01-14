using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class StudentExamsListVm : IMapFrom<ExamResult>
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
         
                

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExamResult, StudentExamsListVm>();
                
        }
    }
}
