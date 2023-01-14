using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    public class GetGroupDetailQueryValidator : AbstractValidator<GetGroupDetailQuery>
    {
        public GetGroupDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required group id");
        }
    }
}
