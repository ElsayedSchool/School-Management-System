using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentParentApp
{
    public class UpsertStudentParentsCommandValidator : AbstractValidator<UpsertStudentParentCommand>
    {
        public UpsertStudentParentsCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.StudentId).ValidateIntKey();

            RuleFor(p => p.ParentId).ValidateIntKey();

            RuleFor(p => p.IsApproved);

        }
    }
}
