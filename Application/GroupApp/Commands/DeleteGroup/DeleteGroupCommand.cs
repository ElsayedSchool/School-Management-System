﻿using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    public class DeleteGroupCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
    }
}
