﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class GetExamDetailQuery: IRequestWrapper<ExamDetailVm>
    {
        public int Id { get; set; }
    }
}