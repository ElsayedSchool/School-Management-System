﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class GetExamResultDetailQuery: IRequestWrapper<ExamResultDetailVm>
    {
        public int Id { get; set; }
    }
}
