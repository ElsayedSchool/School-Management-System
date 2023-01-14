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
    public class BranchRepo : Repository<Branch>, IBranchRepo
    {
        public BranchRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
