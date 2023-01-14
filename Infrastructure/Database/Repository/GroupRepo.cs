using Application.ClassApp;
using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class GroupRepo : Repository<Group>, IGroupRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public GroupRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        
    }
}
