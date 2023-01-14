using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryCourseApp
{
    public class UpsertCategoryCourseCommandValidator : AbstractValidator<UpsertCategoryCourseCommand>
    {
        public UpsertCategoryCourseCommandValidator()
        {
            RuleFor(p => p.Id);
                
            RuleFor(p=> p.CourseId).ValidateIntKey();

            RuleFor(p=>p.CategoryId).ValidateIntKey();

            RuleFor(p => p.EnglishDesc).ValidateDescription();

            RuleFor(p => p.EnglishDesc).ValidateDescription();
            
        }
    }
}
