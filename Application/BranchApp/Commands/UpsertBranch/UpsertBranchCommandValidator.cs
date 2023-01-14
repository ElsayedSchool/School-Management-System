using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class UpsertBranchCommandValidator : AbstractValidator<UpsertBranchCommand>
    {
        public UpsertBranchCommandValidator()
        {
            RuleFor(p => p.BranchName).ValidateName();

            RuleFor(p => p.BranchDesc).ValidateDescription(false, 50);

            RuleFor(p => p.Phone1).ValidatePhone();
                
            RuleFor(p => p.Email).ValidateEmail();

            RuleFor(p => p.Phone2).ValidatePhone(false);

            RuleFor(p => p.CountryId).ValidateIntKey();

            RuleFor(p => p.CityId).ValidateIntKey();
            
            RuleFor(p => p.RegionId).ValidateIntKey();
            
            RuleFor(p => p.Street).ValidateDescription(false,80);

        }
    }
}
