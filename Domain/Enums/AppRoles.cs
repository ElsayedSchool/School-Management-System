using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public static class AppRoles
    {
        public const string Admin = "Admin";
        public const string Teacher = "Teacher";
        public const string Student = "Student";
        public const string Parent = "Parent";
        public const string Secretary = "Secretary";
    }

    public enum AppRole
    {
        Owner,
        Admin,
        Teacher,
        Student,
        Parent,
        Secretary
    }
}
