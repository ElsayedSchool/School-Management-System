using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    public class UpsertGroupCommandValidator : AbstractValidator<UpsertGroupCommand>
    {
        public UpsertGroupCommandValidator()
        {
            RuleFor(p => p.GroupName).ValidateName();

            RuleFor(p => p.StudentPayment).ValidateGreaterThan();

            RuleFor(p => p.BranchId).ValidateIntKey();

            RuleFor(p => p.GradeId).ValidateIntKey();

        }
    }
}
