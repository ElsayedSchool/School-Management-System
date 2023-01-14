using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class ProfileDetailVm : IMapFrom<UserProfile>
    {
        public int Id { get; set; }
    }
}
