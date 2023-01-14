﻿using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentApp
{
    public class StudentsListVm : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentsListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.StudentId));
        }
    }
}
