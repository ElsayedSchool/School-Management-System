using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentAbsenceApp
{
    public class UpsertStudentAbsencesCommandValidator : AbstractValidator<UpsertStudentAbsenceCommand>
    {
        public UpsertStudentAbsencesCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.StudentId).ValidateIntKey();

            RuleFor(p => p.SessionId).ValidateIntKey();

        }
    }
}
