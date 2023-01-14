using Application.Common.CustomValidators;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeApp
{
    public class UpsertEmployeeCommandValidator : AbstractValidator<UpsertEmployeeCommand>
    {
        public UpsertEmployeeCommandValidator()
        {
            RuleFor(p => p.Id);
            
            RuleFor(p => p.WorkEndTime)
                .GreaterThan(p => p.WorkStartTime).WithMessage("Work end time should be greater than start time");

            RuleFor(p => p.Salary).ValidateGreaterThan();

            RuleFor(p => p.BranchId).ValidateIntKey();
        }
    }
}
