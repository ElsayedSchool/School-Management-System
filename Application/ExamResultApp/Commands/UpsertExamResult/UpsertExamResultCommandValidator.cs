using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class UpsertExamResultCommandValidator : AbstractValidator<UpsertExamResultCommand>
    {
        public UpsertExamResultCommandValidator()
        {
            RuleFor(p => p.StudentId).ValidateIntKey();

            RuleFor(p => p.ExamId).ValidateIntKey();

            RuleFor(p => p.Score).ValidateGreaterThan(-1);

        }
    }
}
