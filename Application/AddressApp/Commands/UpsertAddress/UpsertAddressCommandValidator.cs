using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class UpsertAddressCommandValidator: AbstractValidator<UpsertAddressCommand>
    {
        public UpsertAddressCommandValidator()
        {
            RuleFor(p => p.RegionId).ValidateIntKey();
        }
    }
}
