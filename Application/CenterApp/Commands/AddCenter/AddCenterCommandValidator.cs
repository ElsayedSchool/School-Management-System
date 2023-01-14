using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public class AddCenterCommandValidator : AbstractValidator<AddCenterCommand>
    {
        public AddCenterCommandValidator()
        {
            RuleFor(X => X.CenterId);
            RuleFor(x => x.OwnerId).ValidateName(false, 100);
            RuleFor(x => x.OverView).ValidateDescription();
            RuleFor(x => x.CenterName).ValidateName();
            RuleFor(x => x.CenterNameInEnglish).ValidateName(true);
            RuleFor(x => x.LoginPagePhotoPath).ValidateMaxLength(false, 150);
            RuleFor(x => x.LogoPhotoPath).ValidateMaxLength(false, 150);
        }
    }
}
