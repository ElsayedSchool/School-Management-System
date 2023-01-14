using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.GroupApp
{
    public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
