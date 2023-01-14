using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class RegionRepo : Repository<Region>, IRegionRepo
    {
        public RegionRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
