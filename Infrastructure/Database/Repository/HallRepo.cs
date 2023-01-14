using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using Infrastructure.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class HallRepo : Repository<Hall>, IHallRepo
    {
        public HallRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
