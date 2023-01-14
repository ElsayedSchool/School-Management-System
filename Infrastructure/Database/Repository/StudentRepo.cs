using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class StudentRepo : Repository<Student>, IStudentRepo
    {
        public StudentRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
