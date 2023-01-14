using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class GetSessionDetailQueryValidator : AbstractValidator<GetSessionDetailQuery>
    {
        public GetSessionDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please send required Session id");
        }
    }
}
