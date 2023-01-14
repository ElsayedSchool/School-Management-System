using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class ParentRepo : Repository<Parent>, IParentRepo
    {
        public ParentRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
