using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public class UpdateCenterCommandValidator : AbstractValidator<UpdateCenterCommand>
    {
        public UpdateCenterCommandValidator()
        {
            RuleFor(p => p.Id).NotEqual(0);
            RuleFor(p => p.Data).NotNull();
        }
    }
}
