using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class UpsertTeacherCommandValidator : AbstractValidator<UpsertTeacherCommand>
    {
        public UpsertTeacherCommandValidator()
        {
            RuleFor(p => p.Id);
            
            RuleFor(p => p.CourseId).ValidateIntKey();

            RuleFor(p => p.YearsOfExperience).ValidateGreaterThan();

    }
    }
}
