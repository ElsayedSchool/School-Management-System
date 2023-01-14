using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class GetClassDetailQueryValidator : AbstractValidator<GetClassDetailQuery>
    {
        public GetClassDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required class id");
        }
    }
}
