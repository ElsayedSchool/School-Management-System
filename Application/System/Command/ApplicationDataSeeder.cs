using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.System.Command
{
    public class ApplicationDataSeeder
    {
        private readonly IApplicationRepo _applicationRepo;
        private readonly IUserManagerService _userManager;
        private readonly IUserSignInManagerService _userSignInManager;
        private readonly IOptions<AppSettingModel> _options;

        public ApplicationDataSeeder(
            IApplicationRepo applicationRepo, 
            IUserManagerService userManager,
            IUserSignInManagerService userSignInManager,
            IOptions<AppSettingModel> options)
        {
            _applicationRepo = applicationRepo;
            _userManager = userManager;
            _userSignInManager = userSignInManager;
            _options = options;
        }

        public async  Task SeedAllAsync(CancellationToken cancellationToken)
        {
            var users = await _userManager.HasAny();
            if (users != null && users.Data != true)
            {
                await SeedRoles();
                await SeedAdmins();
            }
            await SeedCenter();
            await SeedRegions();
            await SeedCourses();
            await SeedPrimaryAndMiddleGrades();
            await _applicationRepo.Commit();
           
        }

        private async Task SeedRoles()
        {
            var Roles = new List<IdentityRole>()
            {
                new IdentityRole() {Name = AppRoles.Student},
                new IdentityRole() {Name = AppRoles.Parent},
                new IdentityRole() {Name = AppRoles.Admin},
                new IdentityRole() {Name = AppRoles.Teacher}
            };
            foreach(var role in Roles)
            {
                await _userSignInManager.AddRoleAsync(role);
            }
        }

        private async Task SeedAdmins()
        {
            var admins = new List<ApplicationUser>()
            {
                new ApplicationUser() {UserName = "AppAdminA"},
                new ApplicationUser() {UserName = "AppAdminB"}
            };

            foreach (var admin in admins)
            {
                await _userManager.CreateUserAsync(admin.UserName, _options.Value.AdminPassword, admin.UserName);
                var user = await _userManager.GetUserByNameAsync(admin.UserName);
                await _userManager.AddUserToRoleAsync(user, AppRoles.Admin);
            };
        }

        private async Task SeedRegions()
        {
            if (await _applicationRepo.CountryRepo.HasAny())
            {
                return;
            }
            var AddressesPoints = new List<Country>()
            {
                new Country(){
                    CountryName = "مصر",
                    EnglishName = "Egypt",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            CityName = "الاسكندريه",
                            EnglishName = "Alexandria",
                            Regions = new List<Region>()
                            {
                                new Region()
                                {
                                    RegionName = "سموحه",
                                    EnglishName = "Smouha"
                                },
                                new Region()
                                {
                                    RegionName = "المندره",
                                    EnglishName = "El-Mandara"
                                },
                                new Region()
                                {
                                    RegionName = "العصافره",
                                    EnglishName = "El-Asafra"
                                },
                                new Region()
                                {
                                    RegionName = "سيدى بشر",
                                    EnglishName = "Sidi Bishr"
                                },
                                new Region()
                                {
                                    RegionName = "الورديان",
                                    EnglishName = "El-Wardian"
                                },
                                new Region()
                                {
                                    RegionName = "العجمى",
                                    EnglishName = "El-Agamy"
                                },
                                new Region()
                                {
                                    RegionName = "الهانوفيل",
                                    EnglishName = "El-Hanovel"
                                },
                                new Region()
                                {
                                    RegionName = "ابو يوسف",
                                    EnglishName = "Abo Youssef"
                                },
                                new Region()
                                {
                                    RegionName = "الكيلو 21",
                                    EnglishName = "El-kilo 21"
                                },
                            }
                        }
                    }
                }
            };
           
            await _applicationRepo.CountryRepo.CreateListAsync(AddressesPoints);
        }

        private async Task SeedCenter()
        {
            var AppAdminAId = await _userManager.GetUserByNameAsync("AppAdminA");
            var newCenter = new Center()
            {
                OwnerId = AppAdminAId.Id,
                Setting = new Setting()
            };
            if (await _applicationRepo.CenterRepo.HasAny())
            {
                return;
            }

            await _applicationRepo.CenterRepo.CreateAsync(newCenter);
        }

        private async Task SeedCourses()
        {
            if (await _applicationRepo.CourseRepo.HasAny())
            {
                return;
            }
            else
            {
                var courses = new List<Course>()
                {
                    new Course(){ CourseName = "Arabic", EnglishName = "عربى" },
                    new Course(){ CourseName = "Religion", EnglishName = "دين" },
                    new Course(){ CourseName = "English", EnglishName = "انجليزى" },
                    new Course(){ CourseName = "Math", EnglishName = "رياضه" },
                    new Course(){ CourseName = "Science", EnglishName = "علوم" },
                    new Course(){ CourseName = "ٍSocial Study", EnglishName = "دراسات" },
                    
                    new Course(){ CourseName = "Mechanic", EnglishName = "ميكانيكا" },
                    new Course(){ CourseName = "History", EnglishName = "تاريخ" },
                    new Course(){ CourseName = "French", EnglishName = "فرنساوى" },
                    new Course(){ CourseName = "Static", EnglishName = "استاتيكا" },
                };
                await _applicationRepo.CourseRepo.CreateListAsync(courses);
                await _applicationRepo.Commit();
            }
        }

        private async Task SeedPrimaryAndMiddleGrades()
        {
            if (await _applicationRepo.CategoryRepo.HasAny())
            {
                return;
            }
            var grades = new List<Category>()
                {
                    new Category()
                    {
                        CategoryName = "المرحله الابتدائيه",
                        EnglishName = "Primary School",
                        SubCategories = new List<Category>()
                        {
                            new Category()
                            {
                                CategoryName = "الصف الاول الابتدائى",
                                EnglishName = "Primary(First Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الاول الابتدائى", EnglishDesc = "Arabic (Primary-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الاول الابتدائى", EnglishDesc = "Religion (Primary-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الاول الابتدائى", EnglishDesc = "English (Primary-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الاول الابتدائى", EnglishDesc = "Math (Primary-FirstYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الثانى الابتدائى",
                                EnglishName = "Primary(Second Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الثانى الابتدائى", EnglishDesc = "Arabic (Primary-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الثانى الابتدائى", EnglishDesc = "Religion (Primary-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الثانى الابتدائى", EnglishDesc = "English (Primary-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الثانى الابتدائى", EnglishDesc = "Math (Primary-SecondYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الثالث الابتدائى",
                                EnglishName = "Primary(Third Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الثالث الابتدائى", EnglishDesc = "Arabic (Primary-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الثالث الابتدائى", EnglishDesc = "Religion (Primary-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الثالث الابتدائى", EnglishDesc = "English (Primary-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الثالث الابتدائى", EnglishDesc = "Math (Primary-ThirdYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الرابع الابتدائى",
                                EnglishName = "Primary(Fourth Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الرابع الابتدائى", EnglishDesc = "Arabic (Primary-FourthYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الرابع الابتدائى", EnglishDesc = "Religion (Primary-FourthYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الرابع الابتدائى", EnglishDesc = "English (Primary-FourthYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الرابع الابتدائى", EnglishDesc = "Math (Primary-FourthYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف الرابع الابتدائى", EnglishDesc = "English (Primary-FourthYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف الرابع الابتدائى", EnglishDesc = "Math (Primary-FourthYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الخامس الابتدائى",
                                EnglishName = "Primary(Fifth Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الخامس الابتدائى", EnglishDesc = "Arabic (Primary-FifthYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الخامس الابتدائى", EnglishDesc = "Religion (Primary-FifthYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الخامس الابتدائى", EnglishDesc = "English (Primary-FifthYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الخامس الابتدائى", EnglishDesc = "Math (Primary-FifthYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف الخامس الابتدائى", EnglishDesc = "Science (Primary-FifthYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف الخامس الابتدائى", EnglishDesc = "Social Study (Primary-FifthYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف السادس الابتدائى",
                                EnglishName = "Primary(Sixth Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف السادس الابتدائى", EnglishDesc = "Arabic (Primary-SixthYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف السادس الابتدائى", EnglishDesc = "Religion (Primary-SixthYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف السادس الابتدائى", EnglishDesc = "English (Primary-SixthYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(رياضيات (الصف السادس الابتدائى", EnglishDesc = "Math (Primary-SixthYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف السادس الابتدائى", EnglishDesc = "English (Primary-SixthYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف السادس الابتدائى", EnglishDesc = "Math (Primary-SixthYear-1)" },
                                }
                            },
                        }
                    },
                    new Category()
                    {
                        CategoryName = "المرحله الاعداديه",
                        EnglishName = "Preporatory School",
                        SubCategories = new List<Category>()
                        {
                            new Category()
                            {
                                CategoryName = "الصف الاول الاعدادي",
                                EnglishName = "Preporatory(First Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الاول الاعدادي", EnglishDesc = "Arabic (Preporatory-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الاول الاعدادي", EnglishDesc = "Religion (Preporatory-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الاول الاعدادي", EnglishDesc = "English (Preporatory-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الاول الاعدادي", EnglishDesc = "Math (Preporatory-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف الاول الاعدادي", EnglishDesc = "Science (Preporatory-FirstYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف الاول الاعدادي", EnglishDesc = "Social Study (Preporatory-FirstYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الثانى الاعدادي",
                                EnglishName = "Preporatory(Second Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الثانى الاعدادي", EnglishDesc = "Arabic (Preporatory-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الثانى الاعدادي", EnglishDesc = "Religion (Preporatory-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الثانى الاعدادي", EnglishDesc = "English (Preporatory-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الثانى الاعدادي", EnglishDesc = "Math (Preporatory-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف الثانى الاعدادي", EnglishDesc = "Science (Preporatory-SecondYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف الثانى الاعدادي", EnglishDesc = "Social Study (Preporatory-SecondYear-1)" },
                                }
                            },
                            new Category()
                            {
                                CategoryName = "الصف الثالث الاعدادي",
                                EnglishName = "Preporatory(Third Year)",
                                CategoryCourses = new List<CategoryCourse>()
                                {
                                    new CategoryCourse() { CourseId = 1, Semster = SemsterTypes.None, CourseDesc = "(لغه عربيه (الصف الثالث الاعدادي", EnglishDesc = "Arabic (Preporatory-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 2, Semster = SemsterTypes.None, CourseDesc = "(التربيه الدينيه (الصف الثالث الاعدادي", EnglishDesc = "Religion (Preporatory-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 3, Semster = SemsterTypes.None, CourseDesc = "(لغه أنجليزيه (الصف الثالث الاعدادي", EnglishDesc = "English (Preporatory-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 4, Semster = SemsterTypes.None, CourseDesc = "(ماده الرياضيات (الصف الثالث الاعدادي", EnglishDesc = "Math (Preporatory-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 5, Semster = SemsterTypes.None, CourseDesc = "(علوم (الصف الثالث الاعدادي", EnglishDesc = "Science (Preporatory-ThirdYear-1)" },
                                    new CategoryCourse() { CourseId = 6, Semster = SemsterTypes.None, CourseDesc = "(دراسات (الصف الثالث الاعدادي", EnglishDesc = "Social Study (Preporatory-ThirdYear-1)" },
                                }
                            },
                        },
                    },
                    
            };
            await _applicationRepo.CategoryRepo.CreateListAsync(grades);
        }//end of ssed primary and middle grades
    }
}
