using Application.Common.Interfaces.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationRepo : IDisposable
    {
        IEmployeeRepo EmployeeRepo { get; }
        ICenterRepo CenterRepo { get; }
        ICenterSettingRepo CenterSettingRepo { get; }
        IBranchRepo BranchRepo { get; }
        IHallRepo HallRepo { get; }
        ICountryRepo CountryRepo { get; }
        ICityRepo CityRepo { get; } 
        IRegionRepo RegionRepo { get; }
        IAddressRepo AddressRepo { get; }
        ICourseRepo CourseRepo { get; }
        ICategoryCourseRepo CategoryCourseRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        IGroupRepo GroupRepo { get; }
        ITeacherRepo TeacherRepo { get; }
        IClassRepo ClassRepo { get; }
        IStudentRepo StudentRepo { get; }
        IParentRepo ParentRepo { get; }
        IStudentParentRepo StudentParentRepo { get; }
        IProfileRepo ProfileRepo { get; }
        IStudentGroupRepo StudentGroupRepo { get; }
        ISessionRepo SessionRepo { get; }
        IAbsenceRepo AbsenceRepo { get; }
        IExamRepo ExamRepo { get; }
        IExamResultRepo ExamResultRepo { get; }
        Task<int> Commit();
    }
}
