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
    public class ExamResultsListVm : IMapFrom<ExamResult>
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ExamTopic { get; set; }
        public string ExamClass { get; set; }
        public int ExamId { get; set; }
                

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExamResult, ExamResultsListVm>();
                
        }
    }
}
