using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class ProfileRepo : Repository<UserProfile>, IProfileRepo
    {
        public ProfileRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
