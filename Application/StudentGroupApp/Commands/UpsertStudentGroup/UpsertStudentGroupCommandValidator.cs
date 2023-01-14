using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentGroupApp
{
    public class UpsertStudentGroupsCommandValidator : AbstractValidator<UpsertStudentGroupCommand>
    {
        public UpsertStudentGroupsCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.StudentId).ValidateIntKey();

            RuleFor(p => p.GroupId).ValidateIntKey();

        }
    }
}
