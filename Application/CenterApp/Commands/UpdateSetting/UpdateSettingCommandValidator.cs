using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
    {
        public UpdateSettingCommandValidator()
        {
            RuleFor(p => p.Id).NotEqual(0).WithMessage("Please Send Setting Id");
            RuleFor(p => p.Data).NotNull().WithMessage("Pelase Send Setting Data");
        }
    }
}
