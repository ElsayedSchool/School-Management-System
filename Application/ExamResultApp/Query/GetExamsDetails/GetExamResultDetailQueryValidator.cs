using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class GetExamResultDetailQueryValidator : AbstractValidator<GetExamResultDetailQuery>
    {
        public GetExamResultDetailQueryValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
