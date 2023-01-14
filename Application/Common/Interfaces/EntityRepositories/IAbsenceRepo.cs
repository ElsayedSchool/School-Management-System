﻿using Application.Common.Models;
using Application.StudentAbsenceApp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.EntityRepositories
{
    public interface IAbsenceRepo : IRepository<StudentAbsence>
    {
        Task<RespDto<List<StudentAbsencesListVm>>> GetAllAbsenceList();
    }
}