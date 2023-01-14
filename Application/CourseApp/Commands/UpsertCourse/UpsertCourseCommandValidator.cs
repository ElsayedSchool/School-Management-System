using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp{
    public class UpsertCourseCommandValidator: AbstractValidator<UpsertCourseCommand>
    {
        public UpsertCourseCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.CourseName).ValidateName();

            RuleFor(p => p.EnglishName).ValidateName(true);
        }
    }
}
