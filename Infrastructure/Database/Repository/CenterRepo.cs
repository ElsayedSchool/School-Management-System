using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class CenterRepo : Repository<Center>, ICenterRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public CenterRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<int> GetCenterId()
        {
            return _applicationDb.Centers.Select(c => c.CenterId).FirstOrDefault();
        }
    }
}
