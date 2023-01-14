using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class GetBranchDetailQueryValidator : AbstractValidator<GetBranchDetailQuery>
    {
        public GetBranchDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required hall data");
        }
    }
}
