using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class UpsertSessionCommandValidator : AbstractValidator<UpsertSessionCommand>
    {
        public UpsertSessionCommandValidator()
        {
            RuleFor(p => p.Id);
            RuleFor(p => p.Title);
            RuleFor(p => p.ClassId).ValidateIntKey();
            RuleFor(p => p.StartDate).NotNull().WithMessage("Session StartDate is required");
            RuleFor(p => p.EndDate)
                .NotNull().WithMessage("Session StartDate is required")
                .GreaterThan(p => p.StartDate).WithMessage("EndDate should be greater than StartDate");

            RuleFor(p => p.Status).IsInEnum().WithMessage("Status Should be in the list");
            RuleFor(p => p.ActualStartDate);
            RuleFor(p => p.ActualEndDate);

        }
    }
}
