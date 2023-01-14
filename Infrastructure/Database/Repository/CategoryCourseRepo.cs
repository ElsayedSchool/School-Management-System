using Application.Common.Interfaces.EntityRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class CategoryCourseRepo : Repository<CategoryCourse>, ICategoryCourseRepo
    {
        public CategoryCourseRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
        }
    }
}
