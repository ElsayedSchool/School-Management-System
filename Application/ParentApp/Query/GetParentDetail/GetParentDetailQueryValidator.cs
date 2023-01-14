using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class GetParentDetailQueryValidator : AbstractValidator<GetParentDetailQuery>
    {
        public GetParentDetailQueryValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
