using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class UpsertProfileCommandValidator : AbstractValidator<UpsertProfileCommand>
    {
        public UpsertProfileCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.FirstName).ValidateName();

            RuleFor(p => p.LastName).ValidateName();

            RuleFor(p => p.Phone).ValidatePhone();

            RuleFor(p => p.JobTitle).ValidateDescription();

            RuleFor(p => p.ReportsTo);
        }
    }
}
