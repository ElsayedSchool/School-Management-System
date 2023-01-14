using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class GetExamDetailQueryValidator : AbstractValidator<GetExamDetailQuery>
    {
        public GetExamDetailQueryValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
