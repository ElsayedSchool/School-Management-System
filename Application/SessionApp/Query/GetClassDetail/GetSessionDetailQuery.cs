﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class GetSessionDetailQuery : IRequestWrapper<SessionDetailVm>
    {
        public int Id { get; set; }
    }
}
