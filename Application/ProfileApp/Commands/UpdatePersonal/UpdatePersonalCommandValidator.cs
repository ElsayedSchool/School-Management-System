using Application.Common.CustomValidators;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class UpdatePersonalCommandValidator : AbstractValidator<UpdatePersonalCommand>
    {
        public UpdatePersonalCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();

            RuleFor(p => p.Photo);

            RuleFor(p => p.PhotoPath);

            RuleFor(p=>p.BirthDate).LessThan(DateTime.Now).WithMessage("Birthdate should be less than today");
        }
    }
}
