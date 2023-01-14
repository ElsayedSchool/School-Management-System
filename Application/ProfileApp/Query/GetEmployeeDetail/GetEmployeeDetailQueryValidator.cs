using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class GetProfileDetailQueryValidator : AbstractValidator<GetProfileDetailQuery>
    {
        public GetProfileDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required hall data");
        }
    }
}
