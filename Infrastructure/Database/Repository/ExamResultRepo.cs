using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class ExamResultRepo : Repository<ExamResult>, IExamResultRepo
    {
        public ExamResultRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
