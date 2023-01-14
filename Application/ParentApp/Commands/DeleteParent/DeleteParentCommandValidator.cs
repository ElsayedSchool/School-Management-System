using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ParentApp
{
    public class DeleteParentCommandValidator : AbstractValidator<DeleteParentCommand>
    {
        public DeleteParentCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
