﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeApp
{
    public class DeleteEmployeeCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
    }
}
