using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.SessionApp
{
    public class DeleteSessionCommandValidator : AbstractValidator<DeleteSessionCommand>
    {
        public DeleteSessionCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
