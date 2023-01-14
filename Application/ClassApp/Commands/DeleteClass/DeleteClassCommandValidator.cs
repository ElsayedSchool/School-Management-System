using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ClassApp
{
    public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
    {
        public DeleteClassCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
