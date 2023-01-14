using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class GetTeacherDetailQueryValidator : AbstractValidator<GetTeacherDetailQuery>
    {
        public GetTeacherDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required Teacher data");
        }
    }
}
