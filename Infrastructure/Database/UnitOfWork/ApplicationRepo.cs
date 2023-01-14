using Application.Common.Interfaces;
using Application.Common.Interfaces.EntityRepositories;
using Infrastructure.Database.Repository;
using Infrastructure.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.UnitOfWork
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly AcademyDbContext _academyDb;

        public ApplicationRepo(
            AcademyDbContext academyDb
            )
        {
            _academyDb = academyDb;
        }

        public IEmployeeRepo EmployeeRepo { 
            get => new EmployeeRepo(_academyDb); 
        }

        public ICenterRepo CenterRepo {
            get => new CenterRepo(_academyDb);
        }

        public ICenterSettingRepo CenterSettingRepo {
            get  => new CenterSettingRepo(_academyDb); 
        }


        public IBranchRepo BranchRepo { 
            get => new BranchRepo(_academyDb);
        }

        public IHallRepo HallRepo {
            get => new HallRepo(_academyDb); 
        }

        public ICountryRepo CountryRepo
        {
            get => new CountryRepo(_academyDb);
        }
        public ICityRepo CityRepo {
            get => new CityRepo(_academyDb); 
        }
        public IRegionRepo RegionRepo {
            get => new RegionRepo(_academyDb); 
        }
        public IAddressRepo AddressRepo {
            get => new AddressRepo(_academyDb); 
        }

        public ICourseRepo CourseRepo
        {
            get => new CourseRepo(_academyDb);
        }

        public ICategoryCourseRepo CategoryCourseRepo
        {
            get => new CategoryCourseRepo(_academyDb);
        }

        public ICategoryRepo CategoryRepo
        {
            get => new CategoryRepo(_academyDb);
        }

        public IGroupRepo GroupRepo
        {
            get => new GroupRepo(_academyDb);
        }

        public ITeacherRepo TeacherRepo
        {
            get => new TeacherRepo(_academyDb);
        }

        public IClassRepo ClassRepo
        {
            get => new ClassRepo(_academyDb);
        }

        public IStudentRepo StudentRepo
        {
            get => new StudentRepo(_academyDb);
        }

        public IParentRepo ParentRepo
        {
            get => new ParentRepo(_academyDb);
        }

        public IStudentParentRepo StudentParentRepo
        {
            get => new StudentParentRepo(_academyDb);
        }

        public IProfileRepo ProfileRepo
        {
            get => new ProfileRepo(_academyDb);
        }

        public IStudentGroupRepo StudentGroupRepo
        {
            get => new StudentGroupRepo(_academyDb);
        }

        public ISessionRepo SessionRepo
        {
            get => new SessionRepo(_academyDb);
        }

        public IAbsenceRepo AbsenceRepo
        {
            get => new AbsenceRepo(_academyDb);
        }

        public IExamRepo ExamRepo
        {
            get => new ExamRepo(_academyDb);
        }

        public IExamResultRepo ExamResultRepo
        {
            get => new ExamResultRepo(_academyDb);
        }

        public async Task<int> Commit()
        {
            return await _academyDb.SaveChangesAsync();
        }
        public void Dispose()
        {
            _academyDb.Dispose();
        }
    }
}
