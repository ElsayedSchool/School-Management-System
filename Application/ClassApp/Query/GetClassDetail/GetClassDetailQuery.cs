﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class GetClassDetailQuery : IRequestWrapper<ClassDetailVm>
    {
        public int Id { get; set; }
    }
}