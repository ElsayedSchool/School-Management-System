using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class UpsertClassCommandValidator : AbstractValidator<UpsertClassCommand>
    {
        public UpsertClassCommandValidator()
        {
            RuleFor(p => p.ClassPrice).ValidateGreaterThan();

            RuleFor(p => p.TeacherId).ValidateIntKey();

            RuleFor(p => p.GroupId).ValidateIntKey();

            RuleFor(p => p.HallId).ValidateIntKey();

            RuleFor(p => p.CourseId).ValidateIntKey();

        }
    }
}
