using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class GetAddressDetailQueryValidator: AbstractValidator<GetAddressDetailQuery>
    {
        public GetAddressDetailQueryValidator()
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1).WithMessage("Please Send Address Id");
        }
    }
}
