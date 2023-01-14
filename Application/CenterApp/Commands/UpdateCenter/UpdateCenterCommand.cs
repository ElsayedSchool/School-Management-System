using Application.CenterApp.Query.GetCenter;
using Application.Common.Mediatr;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public partial class UpdateCenterCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public CenterDetailVm Data { get; set; }
    }
}
